
namespace Practice.Ddd.Application.Utilities.Exceptions;

public class ExceptionResult : IExceptionResult
{
    public bool HasError { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public Type? ExceptionType { get; set; } = null;
}
