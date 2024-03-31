﻿using MediatR;

namespace Practice.Ddd.Application.Commands;

public class CreateUserCommand : ICommand<Unit>
{
    public CreateUserCommand(string userName, string firstName, string familyName)
    {
        UserName = userName;
        FirstName = firstName;
        FamilyName = familyName;
    }

    public string UserName { get; }
    public string FirstName { get; }
    public string FamilyName { get; }
}
