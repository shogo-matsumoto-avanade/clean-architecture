using FluentValidation;
using MediatR;

namespace Practice.Ddd.Application.Pipelines
{
    /// <summary>
    /// Request validation pipeline behavior
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse">If response of the request will be void, you need to specify Unit class to the response.</typeparam>
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
    {
        /// <summary>
        /// Validators for the Handler
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();

            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            
            if (failures.Count == 0) return await next();

            throw new ValidationException(failures);
        }
    }
}
