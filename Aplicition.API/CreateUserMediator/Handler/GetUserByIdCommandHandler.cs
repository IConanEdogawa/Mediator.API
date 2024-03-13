using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Query;
using Mediator.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Applicition.CreateUserMediator.Handler
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdQueryCommand, User>
    {
        private readonly IApplicitionDbContext _dbContext;

        public GetUserByIdCommandHandler(IApplicitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(GetUserByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.isDeleted != true);

            return user;
        }
    }
}
