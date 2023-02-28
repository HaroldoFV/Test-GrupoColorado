using GrupoColorado.Domain.Entities;

namespace GrupoColorado.Domain.ValueObjects;

public class Address
{
    public Address()
    {
    }

    public Address(string street, int number, string neighborhood, string city, string state, string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public long CustomerId { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public virtual Customer Customer { get; set; }

    public void SetCustomerId(long customerId)
    {
        CustomerId = customerId;
    }
}