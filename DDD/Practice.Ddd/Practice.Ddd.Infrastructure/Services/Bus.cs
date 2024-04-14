
using Microsoft.Extensions.Logging;

namespace Practice.Ddd.Infrastructure.Services;

internal class Bus : IBus
{
    /// <summary>
    /// Use ILogger for example (need to change)
    /// </summary>
    private readonly ILogger<Bus> _logger;

    public Bus(ILogger<Bus> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(string message, CancellationToken cancellation = default)
    {
        _logger.LogInformation(message);
        return Task.CompletedTask;
    }
}
