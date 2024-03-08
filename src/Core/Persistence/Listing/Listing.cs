namespace Core.Persistence.Listing;

public class Listing<T> : IListResponse<T>
{
    public IList<T> Items { get; set; }
}
