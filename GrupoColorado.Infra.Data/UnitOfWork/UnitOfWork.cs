using GrupoColorado.Domain.Interfaces.Repositories;
using GrupoColorado.Domain.Interfaces.UnitOfWork;
using GrupoColorado.Infra.Data.Contexts;
using GrupoColorado.Infra.Data.Repositories;

namespace GrupoColorado.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private ICustomerRepository _customerRepository;
    private IAddressRepository _addressRepository;

    private readonly GrupoColoradoContext _grupoColoradoContext;
    
    public UnitOfWork(GrupoColoradoContext grupoColoradoContext)
    {
        _grupoColoradoContext = grupoColoradoContext;
    }

    public ICustomerRepository CustomerRepository
    {
        get { return _customerRepository = _customerRepository ?? new CustomerRepository(_grupoColoradoContext); }
    }

    public IAddressRepository AddressRepository
    {
        get { return _addressRepository = _addressRepository ?? new AddressRepository(_grupoColoradoContext); }
    }

    public void Dispose()
    {
        _grupoColoradoContext.Dispose();
    }

    public void Commit()
    {
        _grupoColoradoContext.SaveChanges();
    }
}