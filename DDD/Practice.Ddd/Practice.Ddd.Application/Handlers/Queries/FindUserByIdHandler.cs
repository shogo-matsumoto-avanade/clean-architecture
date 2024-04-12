using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public sealed class FindUserByIdHandler : IQueryHandler<FindUserByIdQuery, FindUserResult>
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
    public async Task<FindUserResult> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.Id);
        var user = await _repository.FindByIdAsync(userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }
        var userDto = UserDtoFactory.Create(user);
        var result = new FindUserResult()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
        };
        return result;
    }
}
