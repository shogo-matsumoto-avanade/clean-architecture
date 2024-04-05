using Practice.Ddd.Application.Commands;
using Practice.Ddd.Application.Utilities.MediatR;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get User Query Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Create(User.Create(request.UserName, request.FirstName, request.FamilyName));
        return Task.FromResult(new CreateUserCommandResult());
    }
}
