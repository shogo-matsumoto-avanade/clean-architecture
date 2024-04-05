using Practice.Ddd.Application.Utilities.MediatR;

namespace Practice.Ddd.Application.Queries;

public class FindUserByIdQuery : IQuery<FindUserByIdResult>
{
    public FindUserByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
