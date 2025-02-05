namespace InfoDengue.Interfaces;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    TEntity GetById(int id);
    List<TEntity> GetAll();
}