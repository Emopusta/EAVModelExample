using Core.Domain;

namespace Domain.Models;

public class Attribute : BaseEntity
{
    public string Name { get; set; }
    public int EntityId { get; set; }


    public virtual Entity Entity { get; set; } = null!;
    public virtual Value Value { get; set; } = null!;
}
