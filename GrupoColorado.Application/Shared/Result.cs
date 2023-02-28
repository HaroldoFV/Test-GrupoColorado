namespace GrupoColorado.Application.Shared;

public class Result
{
    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public Result(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }

    public object Data { get; set; }
    // public long Total { get; set; } = 0;
}