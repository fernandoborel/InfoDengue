using InfoDengue.Context;
using InfoDengue.Interfaces;

namespace InfoDengue.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly InfoDengueDbContext _context;

        public BaseRepository(InfoDengueDbContext context)
           => _context = context;

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
            => _context.Dispose();

        public List<TEntity> GetAll()
            => _context.Set<TEntity>().ToList();

        public TEntity GetById(int id)
            => _context.Set<TEntity>().Find(id);        
    }
}
