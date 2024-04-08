using FluentValidation;
using Practice.Ddd.Application.Requests.Commands;

namespace Practice.Ddd.Application.Validators.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}
