using MediatR;

namespace Practice.Ddd.Application.Utilities.MediatR
{
    /// <summary>
    /// Base Query Handler class
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
        where TQuery : IQuery<TResponse>
        where TResponse : IQueryResult;
}
