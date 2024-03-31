using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Commands;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Web.Models;

namespace Practice.Ddd.Web.Controllers
{
    public class UserController : Controller
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/user/{id}")]
        public async Task<ActionResult<UserViewModel>> Get(string id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            return new UserViewModel()
            {
                UserName = user.UserName,
            };
        }

        [HttpGet("/create/{userName}/{firstName}/{lastName}")]
        public async Task<IActionResult> Add(string userName, string firstName, string lastName)
        {
            await _mediator.Send(new CreateUserCommand(userName, firstName, lastName));
            return Created("/create",
                new UserViewModel()
                {
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName
                });
        }
    }
}
