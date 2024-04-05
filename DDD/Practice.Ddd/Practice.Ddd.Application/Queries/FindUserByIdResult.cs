using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Application.Utilities.Exceptions;
using Practice.Ddd.Application.Utilities.MediatR;

namespace Practice.Ddd.Application.Queries;

public class FindUserByIdResult : ExceptionResult, IQueryResult, IUserModel
{
    public required string UserName { get; set; }
}
