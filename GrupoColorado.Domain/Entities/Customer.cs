using GrupoColorado.Domain.ValueObjects;

namespace GrupoColorado.Domain.Entities;

public class Customer
{
    // código do cliente, nome, endereço, cidade, UF e data de inserção.
    public long Id { get; private set; }
    public string Name { get; private set; }
    public virtual Address Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public DateTime DateInsert { get; private set; }

    // public virtual Address Addresses { get; private set; }

    public Customer()
    {
        
    }
    public Customer(string name, Address address, string city, string state)
    {
        Name = name;
        Address = address;
        City = city;
        State = state;
        DateInsert = DateTime.Now;
    }

    public void Update(string name, string city, string state)
    {
        Name = name;
        City = city;
        State = state;
    }

    public void UpdateAddress(Address address)
    {
        Address = address;
    }
}