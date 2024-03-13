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
        private readonly IApplicitionDbContext _applicitionDbContext;

        public GetUserByIdCommandHandler(IApplicitionDbContext applicitionDbContext)
        {
            _applicitionDbContext = applicitionDbContext;
        }

        public async Task<User> Handle(GetUserByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicitionDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.isDeleted != true);

            return result;

        }
    }
}
