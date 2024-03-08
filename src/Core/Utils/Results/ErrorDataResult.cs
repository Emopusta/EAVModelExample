
namespace Core.Utils.Results;

public class ErrorDataResult<T> : DataResult<T>
{    
    public ErrorDataResult() : base(default, false) { }
}
