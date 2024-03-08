namespace Core.Persistence.UoW;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}
