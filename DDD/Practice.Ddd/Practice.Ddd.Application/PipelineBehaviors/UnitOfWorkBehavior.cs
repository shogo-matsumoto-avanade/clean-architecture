using MediatR;
using Practice.Ddd.Application.Data;
using System.Transactions;

namespace Practice.Ddd.Application.PipelineBehaviors;

/// <summary>
/// Pipeline behavior logging before and after handler execution
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="unitOfWork"></param>
    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }

        using (var transactionScope = new TransactionScope())
        {
            var response = await next();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            transactionScope.Complete();

            return response;
        }
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }
}
