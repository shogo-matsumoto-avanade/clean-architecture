using FluentValidation;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Requests.Queries;

public class FindUserByEmailQueryValidator : AbstractValidator<FindUserByEmailQuery>
{
    public FindUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(Email.FormatPattern);
    }
}
