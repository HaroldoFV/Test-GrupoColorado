namespace GrupoColorado.Application.Shared.Interfaces;

public interface IResult
{
    bool Success { get; set; }
    string Message { get; set; }

    object Data { get; set; }
    // long Total { get; set; }
}