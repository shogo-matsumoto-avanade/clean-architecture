using FluentValidation;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Requests.Queries.Validators;

public class FindUserByEmailByQueryValidator : AbstractValidator<FindUserByEmailQuery>
{
    public FindUserByEmailByQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(Email.FormatPattern);
    }
}
