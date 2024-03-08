namespace Core.Utils.Results;

public class Result : IResult
{
    public bool Success { get; }

    public Result(bool success)
    {
        Success = success;
    }
}
