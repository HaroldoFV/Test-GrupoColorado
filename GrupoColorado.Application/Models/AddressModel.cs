namespace GrupoColorado.Application.Models;

public record AddressModel
{
    public string Street { get; init; }
    public int Number { get; init; }
    public string Neighborhood { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    
    public string ZipCode { get; init; }
}