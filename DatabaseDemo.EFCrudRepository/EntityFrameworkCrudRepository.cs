using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DatabaseDemo.Contracts;

namespace DatabaseDemo.EFCrudRepository
{
    public class EntityFrameworkCrudRepository<TContext> : ICrudRepository where TContext : DbContext
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
        
        public int Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        
        public int Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return 0;

            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
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
    }
}
