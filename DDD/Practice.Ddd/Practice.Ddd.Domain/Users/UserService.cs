namespace Practice.Ddd.Domain.Users;

/// <summary>
/// Domain Service: User
/// Inject repositories in signature (not in constructor)
/// </summary>
/// <remarks>
/// Manage only logics that are not suitable as domain object logics 
/// (You should ask if it is an application service logic or a domain service logic)
/// </remarks>
public class UserService
{
    public async Task<bool> IsDeplicatedEmailAsync(IUserRepository repository, Email email)
    { 
        var user = await repository.FindByEmailAsync(email);
        return user is not null;
    }

}
