using Practice.Ddd.Application.Utilities.Requests;

namespace Practice.Ddd.Application.Requests.Commands;

public class CreateUserCommand : ICommand<CreateUserCommandResult>
{
    public CreateUserCommand(string firstName, string familyName, string email)
    {
        FirstName = firstName;
        FamilyName = familyName;
        Email = email;
    }

    public string FirstName { get; }
    public string FamilyName { get; }
    public string Email { get; }
}
