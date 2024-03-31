using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class GetUserHandler : QueryHandler<GetUserQuery, IUserModel>
{
    private readonly IUserRepository _repository;

    public GetUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<IUserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = _repository.Find(new UserId(request.Id));
        IUserModel model = UserModelFactory.Create(user);
        return Task.FromResult(model);
    }
}
