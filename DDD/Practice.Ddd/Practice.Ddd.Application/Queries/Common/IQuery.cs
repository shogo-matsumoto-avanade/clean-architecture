using MediatR;

namespace Practice.Ddd.Application.Queries;

public interface IQuery<TQueryResult> : IRequest<TQueryResult>
{
}
