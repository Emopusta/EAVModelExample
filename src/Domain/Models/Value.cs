using Core.Domain;

namespace Domain.Models;

public class Value : BaseEntity
{
    public string Name { get; set; }
    public int AttributeId { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;
}
