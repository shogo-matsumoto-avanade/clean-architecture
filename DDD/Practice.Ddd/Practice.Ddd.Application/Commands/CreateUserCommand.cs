using Practice.Ddd.Application.Utilities.MediatR;

namespace Practice.Ddd.Application.Commands;

public class CreateUserCommand : ICommand<CreateUserCommandResult>
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
