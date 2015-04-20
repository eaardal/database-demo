using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;

namespace DatabaseDemo.EFCrudRepository
{
    public class EntityFrameworkCompleteRepository<TContext> : IComplexRepository where TContext : DbContext
    {
        private readonly TContext _context;

        public EntityFrameworkCompleteRepository(TContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public TEntity GetById<TEntity>(int entityId) where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Find(entityId);
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int entityId) where TEntity : EntityBase
        {
            return await _context.Set<TEntity>().FindAsync(entityId);
        }

        public ICollection<TEntity> GetAll<TEntity>() where TEntity : EntityBase
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null) return;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null) return;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null)
            {
                Insert(entity);
            }
            
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
        
        public async Task InsertOrUpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null)
            {
                await InsertAsync(entity);
            }

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : EntityBase
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            return _context.Set<TEntity>().SingleOrDefault(match);
        }

        public async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public ICollection<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Where(match).ToList();
        }

        public async Task<ICollection<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        public int Count<TEntity>() where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Count();
        }

        public async Task<int> CountAsync<TEntity>() where TEntity : EntityBase
        {
            return await _context.Set<TEntity>().CountAsync();
        }
    }
}
