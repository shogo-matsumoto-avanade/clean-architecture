using Practice.Ddd.Application.Utilities.Requests;

namespace Practice.Ddd.Application.Requests.Queries;

public class FindUserByEmailQuery : IQuery<FindUserResult>
{
    public FindUserByEmailQuery(string email)
    {
        Email = email;
    }

    public string Email { get; }
}
