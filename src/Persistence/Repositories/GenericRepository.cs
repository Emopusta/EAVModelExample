using Core.Application.GenericRepository;
using Core.Domain;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenericRepository<TEntity> : EfRepositoryBase<TEntity, EAVContext>, IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    public GenericRepository(EAVContext context) : base(context) { }
}
