using FluentValidation;

namespace Practice.Ddd.Application.Requests.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(255)
            .Matches("^[A-Za-z0-9]+[A-Za-z0-9_.-]*@[A-Za-z0-9_.-]+\\.[A-Za-z0-9]+$");
    }
}
