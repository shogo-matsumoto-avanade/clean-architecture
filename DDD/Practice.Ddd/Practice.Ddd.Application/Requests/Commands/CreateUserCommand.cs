using Practice.Ddd.Application.Utilities.Requests;

namespace Practice.Ddd.Application.Requests.Commands;

public class CreateUserCommand : ICommand<CreateUserCommandResult>
{
    public CreateUserCommand(string firstName, string familyName, string email)
    {
        FirstName = firstName;
        LastName = familyName;
        Email = email;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
}
