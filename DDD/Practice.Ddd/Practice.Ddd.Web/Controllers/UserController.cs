﻿using MediatR;
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

    [HttpGet("/user/create")]
    public async Task<IActionResult> Add([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string email)
    {
        var result = await _mediator.Send(new CreateUserCommand(firstName, lastName, email));
        if (result.HasError)
        {
            return BadRequest(result.Message);
        }

        //User should be find from DB.
        var userName = $"{firstName} {lastName}";

        await _mediator.Publish(new UserCreatedNotification()
        {
            User = UserModelFactory.Create(userName, email),
        });
        return Created("/user/create",
            new UserViewModel()
            {
                UserName = userName,
                Email = email,
            });
    }
}
