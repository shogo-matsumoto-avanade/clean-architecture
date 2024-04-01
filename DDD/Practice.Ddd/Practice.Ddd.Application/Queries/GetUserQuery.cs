namespace Practice.Ddd.Application.Queries;

public class GetUserQuery : IQuery<GetUserQueryResult>
{
    public GetUserQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
