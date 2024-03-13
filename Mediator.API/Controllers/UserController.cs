﻿using Mediator.Applicition.CreateUserMediator.Command;
using Mediator.Applicition.CreateUserMediator.Query;
using Mediator.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {

            await _mediator.Send(command);

            return Ok("Created !");
        }


        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetAllUsersCommandQuery());

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<User>> GetUserById(GetUserByIdQueryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
