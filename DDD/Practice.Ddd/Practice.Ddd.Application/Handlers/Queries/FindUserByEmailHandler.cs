using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public sealed class FindUserByEmailHandler : IQueryHandler<FindUserByEmailQuery, FindUserResult>
{
    private readonly IUserRepository _repository;

    public FindUserByEmailHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<FindUserResult> Handle(FindUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.FindByEmailAsync(new Email(request.Email));
        var userModel = UserModelFactory.Create(user);
        var model = new FindUserResult()
        {
            UserName = userModel.UserName,
            Email = userModel.Email,
        };
        return model;
    }
}
