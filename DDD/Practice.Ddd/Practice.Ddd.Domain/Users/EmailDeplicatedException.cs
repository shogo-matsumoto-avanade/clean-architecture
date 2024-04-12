namespace Practice.Ddd.Domain.Users;

public class EmailDeplicatedException : Exception
{
    public EmailDeplicatedException(Email email) 
        : base($"The email {email.Value} has been already regsitered")
    {
    }
}
