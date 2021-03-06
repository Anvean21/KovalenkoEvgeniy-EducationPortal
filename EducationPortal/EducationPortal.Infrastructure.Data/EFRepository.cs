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

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });

            await this.entities.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await this.entities.AddRangeAsync(entities);
        }

        public Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public async Task Update(TEntity entity)
        {
             this.entities.Update(entity);

            context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });

            await this.context.SaveChangesAsync();
        }

       

        public async Task<TEntity> FindAsync(int id)
        {
            return await this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification)
        {
            var includes = Include(specification);

            return await includes.Where(specification.Expression).ToListAsync().ConfigureAwait(false);
        }

        public Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize)
        {
            var includes = Include(specification);

            return includes.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize);
        }

        public Task RemoveAsync(int entityId)
        {
            var deleteItem = entities.FindAsync(entityId).Result;
            entities.Remove(deleteItem);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<TEntity> FindAsync(Specification<TEntity> specification)
        {
            var includes = Include(specification);

            return await includes.FirstOrDefaultAsync(specification.Expression);
        }

        private IQueryable<TEntity> Include(Specification<TEntity> specification)
        {
            var query = entities.Where(x => true);

            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
