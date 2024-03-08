
namespace Core.Utils.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    public T Data { get; }

    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }
}
