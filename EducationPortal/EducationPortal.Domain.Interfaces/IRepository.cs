using EducationPortal.Domain.Core;
using EFlecture.Core.Models;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BasicEntity
    {
        Task SaveAsync();
        Task<TEntity> FindAsync(int id);

        Task<TEntity> FindAsync(Specification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification);

        Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task UpdateAsync(IEnumerable<TEntity> entity);

        Task RemoveAsync(int entityId);

        Task RemoveAsync(IEnumerable<TEntity> entity);
    }
}
