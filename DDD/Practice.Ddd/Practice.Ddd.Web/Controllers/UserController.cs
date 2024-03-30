using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Domain.Users;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(string id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            
            if (new UserId("aa") == new UserId("aa"))
            {
                return new UserViewModel()
                {
                    UserName = "UserId is a value object."
                };
            }

            return new UserViewModel()
            {
                UserName = user.UserName,
            };
        }
    }
}
