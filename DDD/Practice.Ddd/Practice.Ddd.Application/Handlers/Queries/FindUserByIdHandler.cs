using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class FindUserByIdHandler : IQueryHandler<FindUserByIdQuery, FindUserByIdResult>
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
    public Task<FindUserByIdResult> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = UserModelFactory.Create(_repository.Find(new UserId(request.Id)));
        var model = new FindUserByIdResult()
        {
            UserName = user.UserName,
            Email = user.Email,
        };
        return Task.FromResult(model);
    }
}
