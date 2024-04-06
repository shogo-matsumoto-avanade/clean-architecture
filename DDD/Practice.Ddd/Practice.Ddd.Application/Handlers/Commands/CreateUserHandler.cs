using MediatR;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Utilities.Requests;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Persistence;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly ApplicationDbContext _context;
    private readonly IPublisher _publisher;

    public CreateUserHandler(ApplicationDbContext context, IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.FirstName, request.LastName, request.Email);
        
        _context.Add(user);

        _publisher.Publish(new UserCreatedEvent(user.UserName, user.Email), cancellationToken);
        
        return Task.FromResult(new CreateUserCommandResult());
    }
}
