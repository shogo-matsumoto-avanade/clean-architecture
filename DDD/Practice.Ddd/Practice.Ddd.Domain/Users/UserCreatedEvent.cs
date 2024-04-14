using Practice.Ddd.Domain.Primitives;

namespace Practice.Ddd.Domain.Users;

public record UserCreatedEvent : DomainEvent
{
    public UserId UserId { get; private set; }
    public string UserName { get; private set; }
    public Email Email { get; private set; }

    public UserCreatedEvent(Guid id, UserId userId, string userName, Email email) : base(id)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
    }
}
