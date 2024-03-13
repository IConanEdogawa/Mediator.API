﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Applicition.CreateUserMediator.Command
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    
}