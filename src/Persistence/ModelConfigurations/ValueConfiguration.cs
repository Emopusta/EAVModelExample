using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations
{
    public class ValueConfiguration : IEntityTypeConfiguration<Value>
    {
        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.ToTable("values").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
            builder.Property(e => e.AttributeId).HasColumnName("AttributeId");

            builder.HasOne(e => e.Attribute);

            builder.HasData(GetSeeds());
        }

        private static IEnumerable<Value> GetSeeds()
        {
            var values = new List<Value>
        {
            new() { Id = 1, AttributeId = 1, Name = "38.9" },
            new() { Id = 2, AttributeId = 2, Name = "True" },
            new() { Id = 3, AttributeId = 3, Name = "With phlegm, yellowish, streaks of blood" },
            new() { Id = 4, AttributeId = 4, Name = "98" }
        };
            return values;
        }

    }
}
