using MediatR;

namespace Practice.Ddd.Application.Commands;

/// <summary>
/// Interface of Command Request classes which has results.
/// </summary>
/// <typeparam name="TQueryResult"></typeparam>
/// <remarks>
/// If you need a void reponse command, specify Unit class for the response class.
/// </remarks>
public interface ICommand<TQueryResult> : IRequest<TQueryResult>
{
}

