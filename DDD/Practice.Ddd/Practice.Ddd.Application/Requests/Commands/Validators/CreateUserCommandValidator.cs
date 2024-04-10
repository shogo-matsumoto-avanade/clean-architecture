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
            .MaximumLength(255);
    }
}
