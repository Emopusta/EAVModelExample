using Core.Persistence.ModelBuilderExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Attribute = Domain.Models.Attribute;

namespace Persistence.Contexts
{
    public class EAVContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Value> Values { get; set; }

        public EAVContext(DbContextOptions<EAVContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.AddTimestampsToEntities();

            modelBuilder.AddGlobalFilterWithExpression<Entity>(expression: e => !e.DeletedDate.HasValue);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            foreach (var entity in ChangeTracker.Entries())
            {
                if (entity.Entity is Entity baseEntity)
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedDate = now;
                            break;
                        case EntityState.Deleted:
                            baseEntity.DeletedDate = now;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedDate = now;
                            break;
                        default:
                            break;
                    }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
