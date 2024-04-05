using MediatR;

namespace Practice.Ddd.Application.Utilities.MediatR;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : IQueryResult;
