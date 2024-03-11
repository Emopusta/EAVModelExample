using Core.Domain;

namespace Domain.Models;

public class Entity : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
}
