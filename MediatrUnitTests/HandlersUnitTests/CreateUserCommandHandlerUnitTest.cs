using AutoMapper;
using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Command;
using Mediator.Applicition.CreateUserMediator.Handler;
using Mediator.Domain.Entities;
using MediatR;
using Moq;

namespace MediatrUnitTests.HandlersUnitTests
{
    public class CreateUserCommandHandlerUnitTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IApplicitionDbContext> _dbContextMock;

        public CreateUserCommandHandlerUnitTests()
        {
            _mapperMock = new Mock<IMapper>();
            _dbContextMock = new Mock<IApplicitionDbContext>();
        }

        [Fact]
        public async Task Handle_ShouldCreateUser_WhenValidCommand()
        {
            // Arrange
            var createUserCommand = new CreateUserCommand()
            {
                Name = "John Doe" + Guid.NewGuid().ToString().Substring(0, 4), // Random name with unique suffix
                UserName = "@random_user_" + Guid.NewGuid().ToString().Substring(0, 8), // Username with random string
                Bio = "This is a test profile. Welcome!", // Bio in English
                email = "test_" + Guid.NewGuid().ToString() + "@example.com", // Random email
                photo_path = "default_profile_pic.png", // Placeholder photo path
                followers_count = 0, // Initial follower count
                Login = "@random_user_" + Guid.NewGuid().ToString().Substring(0, 8), // Login matching username
                Password = "TestPassword123!@" // Example password
            };

            var newUser = _mapperMock.Object.Map<User>(createUserCommand);
            var existingUser = _dbContextMock.Object.Users.FirstOrDefault(u => u.UserName == newUser.UserName);

            _mapperMock.Setup(m => m.Map<CreateUserCommand, User>(createUserCommand))
            .Returns(newUser);

            _dbContextMock.Setup(db => db.Users.FirstOrDefault(u => u.email == createUserCommand.email))
                .Returns(existingUser);  // Check for existing user with email

            _dbContextMock.Setup(db => db.Users.Add(It.IsAny<User>()));
            _dbContextMock.Setup(db => db.SaveChangesAsync(CancellationToken.None))
                    .ReturnsAsync(1);


            var handler = new CreateUserCommandHandler(_mapperMock.Object, _dbContextMock.Object);

            // Act
            //var result = await handler.Handle(createUserCommand, CancellationToken.None);

            // Assert
            _dbContextMock.Verify(db => db.Users.FirstOrDefault(u => u.email == createUserCommand.email));  // Verify email check
            _dbContextMock.Verify(db => db.Users.Add(newUser));
            _dbContextMock.Verify(db => db.Users.AddAsync(newUser, CancellationToken.None));
            //Assert.Equal(newUser.Id, result);


        }

    }
}
