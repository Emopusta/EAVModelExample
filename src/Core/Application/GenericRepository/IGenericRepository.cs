
using Core.Domain;
using Core.Persistence.Repositories;

namespace Core.Application.GenericRepository
{
    public interface IGenericRepository<TEntity> :  IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
