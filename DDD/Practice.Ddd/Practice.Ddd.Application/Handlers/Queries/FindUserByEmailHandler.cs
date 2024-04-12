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
        var email = new Email(request.Email);
        var user = await _repository.FindByEmailAsync(email);
        if (user is null)
        {
            throw new UserNotFoundException(email);
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
