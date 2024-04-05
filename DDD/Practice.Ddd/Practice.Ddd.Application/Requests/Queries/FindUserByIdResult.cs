using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Application.Utilities.Exceptions;
using Practice.Ddd.Application.Utilities.Requests;

namespace Practice.Ddd.Application.Requests.Queries;

public class FindUserByIdResult : ExceptionResult, IQueryResult, IUserModel
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
}
