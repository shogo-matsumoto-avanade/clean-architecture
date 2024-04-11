using MediatR;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublisher _publisher;
    private readonly UserService _userService;

    public CreateUserHandler(
        IUserRepository userRepository,
        IPublisher publisher,
        UserService userService)
    {
        _userRepository = userRepository;
        _publisher = publisher;
        _userService = userService;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userService.IsDeplicatedEmailAsync(_userRepository, new Email(request.Email)))
        {
            throw new ValidationException($"The email has been already regsitered.");
        }
        var newUser = User.Create(request.FirstName, request.FamilyName, request.Email);

        _userRepository.Add(newUser);

        await _publisher.Publish(new UserCreatedNotification(newUser.Id, newUser.UserName, newUser.Email), cancellationToken);

        return new CreateUserCommandResult();
    }
}
