namespace Core.Persistence.Listing;

public interface IListResponse<T> 
{
    IList<T> Items { get; }
}
