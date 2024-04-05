using MediatR;

namespace Practice.Ddd.Application.Utilities.MediatR;

/// <summary>
/// Interface of command with response.
/// Responseless command have NOT been added because pipeline behaviors skip commands which have no response. 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand where TResponse : ICommandResult;

