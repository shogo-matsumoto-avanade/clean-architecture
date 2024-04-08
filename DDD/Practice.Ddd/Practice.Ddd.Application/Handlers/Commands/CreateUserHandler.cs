using MediatR;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublisher _publisher;

    public CreateUserHandler(IUserRepository userRepository, IPublisher publisher)
    {
        _userRepository = userRepository;
        _publisher = publisher;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.FirstName, request.LastName, request.Email);
        
        _userRepository.Add(user);

        await _publisher.Publish(new UserCreatedEvent(user.Id, user.UserName, user.Email), cancellationToken);
        
        return new CreateUserCommandResult();
    }
}
