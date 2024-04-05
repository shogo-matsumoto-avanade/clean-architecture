using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Web.Models;

namespace Practice.Ddd.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/user")]
        public async Task<ActionResult<UserViewModel>> Get([FromQuery] string? id)
        {
            var user = await _mediator.Send(new FindUserByIdQuery(id!));

            return user.HasError
                ? BadRequest(user.Message)
                : Ok(new UserViewModel()
                {
                    UserName = user.UserName,
                });
        }

        [HttpGet("/user/create")]
        public async Task<IActionResult> Add([FromQuery] string userName, [FromQuery] string firstName, [FromQuery] string lastName)
        {
            var result = await _mediator.Send(new CreateUserCommand(userName, firstName, lastName));
            if (result.HasError)
            {
                return BadRequest(result.Message);
            }
            await _mediator.Publish(new UserCreatedNotification()
            {
                User = UserModelFactory.Create(userName),
            });
            return Created("/user/create",
                new UserViewModel()
                {
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName
                });
        }
    }
}
