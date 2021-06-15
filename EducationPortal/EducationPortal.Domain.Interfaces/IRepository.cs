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
        Task<TEntity> FindAsync(int id);

        Task<TEntity> FindAsync(Specification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification);

        Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize);

        Task<TEntity> AddAsync(TEntity entity);

        void AddAsync(IEnumerable<TEntity> entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateAsync(IEnumerable<TEntity> entity);

        Task<TEntity> RemoveAsync(TEntity entity);

        Task RemoveAsync(IEnumerable<TEntity> entity);
    }
}
