using GrupoColorado.Application.Models;
using GrupoColorado.Application.Shared;
using GrupoColorado.Domain.Entities;

namespace GrupoColorado.Application.Interfaces;

public interface ICustomerAppService
{
    Result Get(int page, int pageSize);
    Result GetById(long id);
    Result GetByName(int page, int pageSize, string name);
    Result Add(RegisterCustomerModel model);
    Result Update(long id, UpdateCustomerModel model);
    Result Delete(long id);
}