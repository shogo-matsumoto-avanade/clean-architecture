using Practice.Ddd.Application.Models.UserModels;

namespace Practice.Ddd.Application.Queries;

public class GetUserQuery : IQuery<IUserModel>
{
    public GetUserQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
