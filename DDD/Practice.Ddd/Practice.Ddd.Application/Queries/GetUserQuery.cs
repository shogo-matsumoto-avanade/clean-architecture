using MediatR;
using Practice.Ddd.Application.Models.UserModels;

namespace Practice.Ddd.Application.Queries;

public class GetUserQuery : IRequest<IUserModel>
{
    public GetUserQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
