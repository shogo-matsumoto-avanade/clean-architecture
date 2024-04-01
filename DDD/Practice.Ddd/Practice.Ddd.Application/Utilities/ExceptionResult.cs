namespace Practice.Ddd.Application.Utilities;

public class ExceptionResult : IExceptionResult
{
    public bool HasError { get; set; } = false;
    public string Message { get; set; } = string.Empty;
}
