namespace Practice.Ddd.Application.Utilities
{
    public interface IExceptionResult
    {
        bool HasError { get; }
        string Message { get; }
    }
}