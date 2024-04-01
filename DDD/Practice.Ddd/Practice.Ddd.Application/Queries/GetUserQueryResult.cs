using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Application.Utilities;

namespace Practice.Ddd.Application.Queries;

public class GetUserQueryResult : ExceptionResult, IQueryResult, IUserModel
{
    public required string UserName { get; set; }
}
