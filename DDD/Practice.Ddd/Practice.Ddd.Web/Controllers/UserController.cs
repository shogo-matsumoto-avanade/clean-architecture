using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Web.Models;

namespace Practice.Ddd.Web.Controllers;

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
                Email = user.Email,
            });
    }

    [HttpGet("/user/email")]
    public async Task<ActionResult<UserViewModel>> GetByEmail([FromQuery] string? email)
    {
        var user = await _mediator.Send(new FindUserByEmailQuery(email!));

        return user.HasError
            ? BadRequest(user.Message)
            : Ok(new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
            });
    }

    [HttpPost("/user/create")]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand request)
    {
        var result = await _mediator.Send(request);
        return result.HasError 
            ? BadRequest(result.Message)
            : Created("/user/create",
                new UserViewModel()
                {
                    UserName = $"{request.FirstName} {request.FamilyName}",
                    Email = request.Email,
                });
    }
}
