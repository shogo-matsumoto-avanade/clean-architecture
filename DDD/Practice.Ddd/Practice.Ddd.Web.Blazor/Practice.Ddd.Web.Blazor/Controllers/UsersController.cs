using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Web.Models;

namespace Practice.Ddd.Web.Blazor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> Get(string id)
    {
        var user = await _mediator.Send(new FindUserByIdQuery(id!));

        if (user.HasError)
        {
            return user.ExceptionType == typeof(UserNotFoundException)
                ? NotFound(user.Message)
                : BadRequest(user.Message);
        }
        return Ok(new UserViewModel()
        {
            UserName = user.UserName,
            Email = user.Email,
        });
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserViewModel>> GetByEmail(string email)
    {
        var user = await _mediator.Send(new FindUserByEmailQuery(email!));

        if (user.HasError)
        {
            return user.ExceptionType == typeof(UserNotFoundException)
                ? NotFound(user.Message)
                : BadRequest(user.Message);
        }
        return Ok(new UserViewModel()
        {
            UserName = user.UserName,
            Email = user.Email,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand request)
    {
        var result = await _mediator.Send(request);
        return result.HasError
            ? BadRequest(result.Message)
            : Created("api/users/create",
                new UserViewModel()
                {
                    UserName = $"{request.FirstName} {request.FamilyName}",
                    Email = request.Email,
                });
    }

}
