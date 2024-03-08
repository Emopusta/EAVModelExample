using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.ModelBuilderExtensions;

public static class GlobalEntityConfigurationExtensions
{
    public static ModelBuilder AddTimestampsToEntities(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedDate").IsRequired();
                modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("UpdatedDate");
                modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("DeletedDate");
            }
        }
        return modelBuilder;
    }
}
