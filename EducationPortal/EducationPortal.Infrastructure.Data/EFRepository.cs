using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EFlecture.Core.Models;
using EFlecture.Core.Specifications;
using EFLecture.Data.EFCore.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BasicEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> entities;

        public EFRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            this.entities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            this.entities.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<TEntity> FindAsync(Specification<TEntity> specification)
        {
            return await this.entities.FirstOrDefaultAsync(specification.Expression);
        }

        public virtual async void AddAsync(IEnumerable<TEntity> entities)
        {
            await this.entities.AddRangeAsync(entities);
            context.SaveChanges();
        }

        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }


        public virtual async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification)
        {
            return await this.entities.Where(specification.Expression).ToListAsync().ConfigureAwait(false);
        }

        public virtual Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize)
        {
            return this.entities.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize);
        }

        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            this.entities.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
            context.SaveChanges();
            return Task.CompletedTask;
        }



        public virtual Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            this.entities.UpdateRange(entities);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
