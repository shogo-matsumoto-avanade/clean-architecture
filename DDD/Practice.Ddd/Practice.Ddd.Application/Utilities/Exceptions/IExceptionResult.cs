namespace Practice.Ddd.Application.Utilities.Exceptions
{
    public interface IExceptionResult
    {
        bool HasError { get; }
        string Message { get; }
    }
}