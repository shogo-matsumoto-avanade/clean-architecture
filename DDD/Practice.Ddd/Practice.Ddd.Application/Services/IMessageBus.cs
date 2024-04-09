namespace Practice.Ddd.Application.Services;

public interface IMessageBus
{
    Task SendAsync(string message);
}
