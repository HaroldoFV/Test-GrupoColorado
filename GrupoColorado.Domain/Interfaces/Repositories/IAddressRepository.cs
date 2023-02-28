using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.ValueObjects;

namespace GrupoColorado.Domain.Interfaces.Repositories;

public interface IAddressRepository
{
    Address GetById(long id);
    void Add(Address address);
    void Update(Address address);
    void Delete(Address address);
}