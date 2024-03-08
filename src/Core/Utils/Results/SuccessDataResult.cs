namespace Core.Utils.Results;
public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data) : base(data, true) { }
    public SuccessDataResult() : base(default, true) { }
}
