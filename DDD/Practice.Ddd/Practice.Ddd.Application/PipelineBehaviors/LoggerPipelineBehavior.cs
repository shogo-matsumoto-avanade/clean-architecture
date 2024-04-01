using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Practice.Ddd.Application.Pipelines
{
    public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public LoggerPipelineBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest)}");
            
            var response = await next();

            _logger.LogInformation($"Handled {typeof(TRequest)}. {(response?.GetType() != typeof(Unit) ? $"Response : {JsonConvert.SerializeObject(response)}" : string.Empty)}");
            return response;
        }
    }
}
