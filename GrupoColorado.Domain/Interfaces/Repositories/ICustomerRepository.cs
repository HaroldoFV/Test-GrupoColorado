using GrupoColorado.Domain.Entities;

namespace GrupoColorado.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    IList<Customer> GetByName(int page, int pageSize, string name);
}