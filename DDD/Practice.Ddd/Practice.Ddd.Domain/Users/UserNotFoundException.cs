namespace Practice.Ddd.Domain.Users;

public class UserNotFoundException : Exception
{
    

    public UserNotFoundException(UserId id) 
        : base($"User is not found by Id : {id.Value}")
    {
    }

    public UserNotFoundException(Email email)
        : base($"User is not found by Email : {email.Value}")
    {
    }
}
