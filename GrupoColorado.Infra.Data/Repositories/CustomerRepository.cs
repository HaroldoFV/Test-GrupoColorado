using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.Interfaces.Repositories;
using GrupoColorado.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GrupoColorado.Infra.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private GrupoColoradoContext _grupoColoradoContext;

    public CustomerRepository(GrupoColoradoContext grupoColoradoContext)
    {
        _grupoColoradoContext = grupoColoradoContext;
    }

    public IList<Customer> Get(int page, int pageSize)
    {
        var query = _grupoColoradoContext.Customers;

        return query
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Customer GetById(long id)
    {
        return _grupoColoradoContext.Customers.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Customer entity)
    {
        _grupoColoradoContext.Add(entity);
    }

    public void Update(Customer entity)
    {
        _grupoColoradoContext.Entry(entity).State = EntityState.Modified;
        _grupoColoradoContext.Set<Customer>().Update(entity);
    }

    public void Delete(Customer entity)
    {
        _grupoColoradoContext.Set<Customer>().Remove(entity);
    }

    public IList<Customer> GetByName(int page, int pageSize, string name)
    {
        var query = from customer in _grupoColoradoContext.Customers
            where EF.Functions.Like(customer.Name.ToUpper(), "%" + name.ToUpper() + "%")
            select customer;

        return query
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }
}