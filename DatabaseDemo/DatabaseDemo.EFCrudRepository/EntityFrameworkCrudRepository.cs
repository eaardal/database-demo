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

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null) return;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
        
        public void Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        
        public void Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null) return;

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
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
    }
}
