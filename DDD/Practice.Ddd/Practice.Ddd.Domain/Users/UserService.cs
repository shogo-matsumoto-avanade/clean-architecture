namespace Practice.Ddd.Domain.Users;

public class UserService
{
    public async Task<bool> IsDeplicatedEmailAsync(IUserRepository repository, Email email)
    { 
        var user = await repository.FindByEmailAsync(email);
        return user is not null;
    }

}
