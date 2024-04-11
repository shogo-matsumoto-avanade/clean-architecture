using FluentValidation;

namespace Practice.Ddd.Application.Requests.Queries;

public class FindUserByIdQueryValidator : AbstractValidator<FindUserByIdQuery>
{
    public FindUserByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
