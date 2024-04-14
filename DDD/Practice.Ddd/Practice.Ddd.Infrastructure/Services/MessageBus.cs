using Practice.Ddd.Application.Services;

namespace Practice.Ddd.Infrastructure.Services;

/// <summary>
/// Abstraction layer of IBus
/// </summary>
internal class MessageBus : IMessageBus
{
    private readonly IBus _bus;

    public MessageBus(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendAsync(string message, CancellationToken cancellationToken = default)
    {
        await _bus.SendAsync(message, cancellationToken);
    }
}
