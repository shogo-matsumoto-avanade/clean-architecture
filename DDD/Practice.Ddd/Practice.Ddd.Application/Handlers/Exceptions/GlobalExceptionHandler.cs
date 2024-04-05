using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Practice.Ddd.Application.Utilities.Exceptions;

namespace Practice.Ddd.Application.Handlers;

public sealed class GlobalExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : IRequest<TResponse>
    where TResponse : ExceptionResult, IExceptionResult, new()
    where TException : Exception
{
    private readonly ILogger<GlobalExceptionHandler<TRequest, TResponse, TException>> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Something went wrong while handling request of type {request}", typeof(TRequest).Name);

        var response = new TResponse()
        {
            HasError = true,
            Message = exception.Message,
        };

        state.SetHandled(response);

        return Task.CompletedTask;
    }
}
