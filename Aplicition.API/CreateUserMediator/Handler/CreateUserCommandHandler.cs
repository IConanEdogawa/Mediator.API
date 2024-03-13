using AutoMapper;
using Mediator.Applicition.Abstractions;
using Mediator.Applicition.CreateUserMediator.Command;
using Mediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Applicition.CreateUserMediator.Handler
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicitionDbContext _applicitionDbContext;
        private readonly IMapper _mapper;
        private IMapper object1;
        private IApplicitionDbContext object2;

        public CreateUserCommandHandler(IApplicitionDbContext applicitionDbContext, IMapper mapper)
        {
            _applicitionDbContext = applicitionDbContext;
            _mapper = mapper;
        }

        public CreateUserCommandHandler(IMapper object1, IApplicitionDbContext object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _applicitionDbContext.Users.AddAsync(user);
            await _applicitionDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
