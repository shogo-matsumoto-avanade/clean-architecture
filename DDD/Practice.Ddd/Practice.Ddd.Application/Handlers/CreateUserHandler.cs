using MediatR;
using Practice.Ddd.Application.Commands;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : CommandHandler<CreateUserCommand, CreateUserCommandResult>
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
    public override Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Create(request.UserName, request.FirstName, request.FamilyName);
        return Task.FromResult(new CreateUserCommandResult());
    }
}
