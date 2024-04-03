namespace Practice.Ddd.Domain.Users;

public class User
{
    private User() { }
    /// <summary>
    /// Constractor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public User(string id, string firstName, string familyName, string email)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(familyName);
        ArgumentNullException.ThrowIfNull(email);

        Id = new UserId(id);
        FirstName = firstName;
        FamilyName = familyName;
        Email = email;
    }

    public UserId Id { get; private set; }
    public string FirstName { get; private set; }
    public string FamilyName { get; private set; }
    public string Email { get; private set; }

    public string UserName
    {
        get
        {
            return $"{FirstName} {FamilyName}";
        }
    }
}
