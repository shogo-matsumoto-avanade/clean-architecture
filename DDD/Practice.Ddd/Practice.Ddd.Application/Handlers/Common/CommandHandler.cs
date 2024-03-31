using MediatR;
using Practice.Ddd.Application.Commands;

namespace Practice.Ddd.Application.Handlers
{
    /// <summary>
    /// Base Command Handler class which has no result.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TCommandResult"></typeparam>
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : class, ICommand
    {
        public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Base Command Handler class which has results.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TCommandResult"></typeparam>
    public abstract class CommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : class, ICommand<TCommandResult>
    {
        public abstract Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken);
    }


}
