using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;

namespace DatabaseDemo.EFCrudRepository
{
    public class EntityFrameworkCrudRepository<TContext> : IComplexRepository where TContext : DbContext
    {
        private readonly TContext _context;

        public EntityFrameworkCrudRepository(TContext context)
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

        public int Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null) return 0;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return _context.SaveChanges();
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null) return 0;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public async Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public int InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null)
            {
                return Insert(entity);
            }
            
            _context.Entry(existing).CurrentValues.SetValues(entity);
            return _context.SaveChanges();
        }
        
        public async Task<int> InsertOrUpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null)
            {
                return await InsertAsync(entity);
            }

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
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
