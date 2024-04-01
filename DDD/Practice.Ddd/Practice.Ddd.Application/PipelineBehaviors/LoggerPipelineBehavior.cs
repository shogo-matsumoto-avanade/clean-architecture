using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Practice.Ddd.Application.Pipelines
{
    public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;
 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling {request}", typeof(TRequest).Name);
            
            var response = await next();

            _logger.LogInformation("Handled {request}. Result : {response}", typeof(TRequest).Name, JsonConvert.SerializeObject(response));
            return response;
        }
    }
}
