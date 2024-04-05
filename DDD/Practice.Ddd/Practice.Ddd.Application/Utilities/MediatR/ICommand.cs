using MediatR;

namespace Practice.Ddd.Application.Utilities.MediatR;

public interface ICommand : IRequest<Unit>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand where TResponse : ICommandResult;

