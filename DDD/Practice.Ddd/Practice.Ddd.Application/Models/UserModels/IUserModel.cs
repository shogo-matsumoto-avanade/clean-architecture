using Practice.Ddd.Application.Queries;

namespace Practice.Ddd.Application.Models.UserModels
{
    public interface IUserModel : IQueryResult
    {
        string UserName { get; }
    }
}
