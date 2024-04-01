using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class FindUserByIdHandler : QueryHandler<FindUserByIdQuery, FindUserByIdResult>
{
    private readonly IUserRepository _repository;

    public FindUserByIdHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<FindUserByIdResult> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = UserModelFactory.Create(_repository.Find(new UserId(request.Id)));
        var model = new FindUserByIdResult()
        {
            UserName = user.UserName
        };
        return Task.FromResult(model);
    }
}
