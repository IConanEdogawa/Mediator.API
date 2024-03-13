using Mediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Applicition.CreateUserMediator.Query
{
    public class GetAllUsersCommandQuery : IRequest<List<User>>
    {

    }
}
