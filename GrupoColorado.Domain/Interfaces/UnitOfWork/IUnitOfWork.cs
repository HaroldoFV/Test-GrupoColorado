using GrupoColorado.Domain.Interfaces.Repositories;

namespace GrupoColorado.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository CustomerRepository { get; }
    IAddressRepository AddressRepository { get; }
    void Commit();
}