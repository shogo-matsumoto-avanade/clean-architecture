using Practice.Ddd.Application.Utilities.Requests;

namespace Practice.Ddd.Application.Requests.Queries;

public class FindUserByIdQuery : IQuery<FindUserByIdResult>
{
    public FindUserByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
