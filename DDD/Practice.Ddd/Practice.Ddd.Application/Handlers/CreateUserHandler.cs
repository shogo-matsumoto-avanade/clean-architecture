using MediatR;
using Practice.Ddd.Application.Commands;
using Practice.Ddd.Application.Factories;
using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
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
    Task IRequestHandler<CreateUserCommand>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Create(request.UserName, request.FirstName, request.FamilyName);
        return Task.CompletedTask;
    }
}
