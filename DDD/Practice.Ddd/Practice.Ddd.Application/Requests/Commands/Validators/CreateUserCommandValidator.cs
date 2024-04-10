using FluentValidation;

namespace Practice.Ddd.Application.Requests.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.FirstName).MaximumLength(50);
        RuleFor(x => x.FamilyName).NotEmpty();
        RuleFor(x => x.FamilyName).MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Email).MaximumLength(255);
    }
}
