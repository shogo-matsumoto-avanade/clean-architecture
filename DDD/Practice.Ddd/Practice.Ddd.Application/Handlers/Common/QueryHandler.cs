using MediatR;
using Practice.Ddd.Application.Queries;

namespace Practice.Ddd.Application.Handlers
{
    /// <summary>
    /// Base Query Handler class
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TQueryResult"></typeparam>
    public abstract class QueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> where TQuery : class, IQuery<TQueryResult>
    {
        public abstract Task<TQueryResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
