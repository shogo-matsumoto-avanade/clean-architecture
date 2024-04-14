using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Ddd.Domain.Primitives;

[NotMapped]
public record DomainEvent(Guid id) : INotification
{
}
