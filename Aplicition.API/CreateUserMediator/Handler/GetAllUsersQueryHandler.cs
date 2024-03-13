using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Query;
using Mediator.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Applicition.CreateUserMediator.Handler
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersCommandQuery, List<User>>
    {
        private readonly IApplicitionDbContext _applicitionDbContext;
        public GetAllUsersQueryHandler(IApplicitionDbContext applicitionDbContext)
        {
            _applicitionDbContext = applicitionDbContext;
        }

        public async Task<List<User>> Handle(GetAllUsersCommandQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicitionDbContext.Users.ToListAsync();

            return users; 
        }
    }
}
