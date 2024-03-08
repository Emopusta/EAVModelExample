using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = Domain.Models.Attribute;

namespace Persistence.ModelConfigurations;

public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.ToTable("attributes").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

        builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
        builder.Property(e => e.EntityId).HasColumnName("EntityId");

        builder.HasOne(e => e.Entity);

        builder.HasData(GetSeeds());
    }

    private static IEnumerable<Attribute> GetSeeds()
    {
        var attributes = new List<Attribute>
        {
            new() { Id = 1, EntityId = 1, Name = "ColorName" },
        };
        return attributes;
    }
}
