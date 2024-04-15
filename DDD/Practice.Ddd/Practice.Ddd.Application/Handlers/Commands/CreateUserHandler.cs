using MediatR;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(
        IUserRepository userRepository,
        IPublisher publisher)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(new Email(request.Email));
        if (user is not null)
        {
            throw new EmailDeplicatedException(new Email(request.Email));
        }
        var newUser = User.Create(request.FirstName, request.FamilyName, request.Email);

        _userRepository.Add(newUser);

        return new CreateUserCommandResult();
    }
}
