using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.Interfaces.Repositories;
using GrupoColorado.Domain.ValueObjects;
using GrupoColorado.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GrupoColorado.Infra.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private GrupoColoradoContext _grupoColoradoContext;

    public AddressRepository(GrupoColoradoContext grupoColoradoContext)
    {
        _grupoColoradoContext = grupoColoradoContext;
    }

    public Address GetById(long id)
    {
        return _grupoColoradoContext.Addresses.FirstOrDefault(x => x.CustomerId == id);
    }

    public void Add(Address address)
    {
        _grupoColoradoContext.Add(address);
    }

    public void Update(Address address)
    {
        _grupoColoradoContext.Entry(address).State = EntityState.Modified;
        _grupoColoradoContext.Set<Address>().Update(address);
    }

    public void Delete(Address address)
    {
        _grupoColoradoContext.Set<Address>().Remove(address);
    }
}