using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;

        public EFRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAsync()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetAsync(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
