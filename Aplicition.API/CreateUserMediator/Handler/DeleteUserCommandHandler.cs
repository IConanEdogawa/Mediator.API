using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Applicition.CreateUserMediator.Handler
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicitionDbContext _context;

        public DeleteUserCommandHandler(IApplicitionDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Find(request.Id);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
