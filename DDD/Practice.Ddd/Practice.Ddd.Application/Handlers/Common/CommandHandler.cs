using MediatR;
using Practice.Ddd.Application.Commands;

namespace Practice.Ddd.Application.Handlers
{
    /// <summary>
    /// Base Command Handler class which has results.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TCommandResult"></typeparam>
    /// <remarks>
    /// If you need a void reponse command, specify Unit class for the response class.
    /// </remarks>
    public abstract class CommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : class, ICommand<TCommandResult>
    {
        public abstract Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken);
    }


}
