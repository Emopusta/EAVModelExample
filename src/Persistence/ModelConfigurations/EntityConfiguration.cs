using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("entities").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.Name).HasColumnType("character varying").HasColumnName("Name");
            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasData(GetSeeds());
        }

        private static IEnumerable<Entity> GetSeeds()
        {
            var entities = new List<Entity>
            {
                new() { Id = 1, Name = "Patient Emre" }
            };
            return entities;
        }
    }
}
