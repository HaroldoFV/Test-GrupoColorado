namespace GrupoColorado.Domain.Interfaces.Repositories;

public interface IRepository<TEntity>
{
    IList<TEntity> Get(int page, int pageSize);
    TEntity GetById(long id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}