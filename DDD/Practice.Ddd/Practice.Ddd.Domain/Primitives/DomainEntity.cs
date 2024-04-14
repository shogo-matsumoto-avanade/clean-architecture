namespace Practice.Ddd.Domain.Primitives;

public abstract class DomainEntity
{
    private readonly List<DomainEvent> _domainEvents = [];

    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    protected void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
