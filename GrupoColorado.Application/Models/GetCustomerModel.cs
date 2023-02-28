namespace GrupoColorado.Application.Models;

public record GetCustomerModel
{
    // public long Id { get; init; }
    public string Name { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public DateTime DateInsert { get; init; }
    public AddressModel Address { get; init; }
}