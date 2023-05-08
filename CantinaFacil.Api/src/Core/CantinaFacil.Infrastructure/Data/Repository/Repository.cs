using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CantinaFacil.Infrastructure.Data.Context;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain;
using System.Linq.Expressions;

namespace CantinaFacil.Infrastructure.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected DataContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(DataContext dataContext)
        {
            _context = dataContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(params object[] ids)
        {
            return await _dbSet.FindAsync(ids);
        }

        public virtual async Task RemoveAsync(params object[] ids)
        {
            var entity = await GetByIdAsync(ids);

            if (entity != null)
                _dbSet.Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
        }

        public virtual void Update(TEntity current, TEntity updated)
        {
            _context.Entry(current).CurrentValues.SetValues(updated);
        }

        public virtual void DetachAll()
        {
            var entityEntries = _context.ChangeTracker.Entries().ToList();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
