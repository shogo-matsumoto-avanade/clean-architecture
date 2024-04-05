using MediatR;

namespace Practice.Ddd.Application.Utilities.Requests;

/// <summary>
/// Command Handler interface with response. 
/// Responseless command handlers have NOT been added because pipeline behaviors skip them. 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : ICommandResult;
