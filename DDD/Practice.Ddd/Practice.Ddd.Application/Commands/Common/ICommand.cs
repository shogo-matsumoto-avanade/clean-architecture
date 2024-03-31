using MediatR;

namespace Practice.Ddd.Application.Commands;

/// <summary>
/// Interface of Command Request classes which has no result.
/// </summary>
/// <typeparam name="TQueryResult"></typeparam>
public interface ICommand : IRequest
{
}

/// <summary>
/// Interface of Command Request classes which has results.
/// </summary>
/// <typeparam name="TQueryResult"></typeparam>
public interface ICommand<TQueryResult> : IRequest<TQueryResult>
{
}

