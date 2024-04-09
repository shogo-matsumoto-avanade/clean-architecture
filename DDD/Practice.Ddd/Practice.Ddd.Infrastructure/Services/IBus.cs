namespace Practice.Ddd.Infrastructure.Services;

/// <summary>
/// Wrapper interface of external service (Bus: Sample)
/// </summary>
public interface IBus
{
    Task SendAsync(string message);
}
