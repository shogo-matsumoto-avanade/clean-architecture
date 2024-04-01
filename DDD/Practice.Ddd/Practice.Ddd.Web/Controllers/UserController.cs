using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Commands;
using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Notifications;
using Practice.Ddd.Application.Queries;
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

            var user = await _mediator.Send(new GetUserQuery(id));
            
            return new UserViewModel()
            {
                UserName = user.UserName,
            };
        }

        [HttpGet("/user/create")]
        public async Task<IActionResult> Add([FromQuery] string userName, [FromQuery] string firstName, [FromQuery] string lastName)
        {
            await _mediator.Send(new CreateUserCommand(userName, firstName, lastName));
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
