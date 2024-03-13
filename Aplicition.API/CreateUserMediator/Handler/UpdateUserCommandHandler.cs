using AutoMapper;
using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Command;
using Mediator.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Applicition.CreateUserMediator.Handler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IApplicitionDbContext _dbContext;

        public UpdateUserCommandHandler(IMapper mapper, IApplicitionDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _dbContext.Users.FindAsync(request.Id);  

            if (oldUser == null)
            {
                
                return "User not found";
            }

            var newUser = _mapper.Map(request, oldUser);  

            _dbContext.Users.Attach(newUser);  
            _dbContext.Users.Entry(newUser).State = EntityState.Modified;  

            await _dbContext.SaveChangesAsync();

            return "User updated successfully";  
        }

    }

}
