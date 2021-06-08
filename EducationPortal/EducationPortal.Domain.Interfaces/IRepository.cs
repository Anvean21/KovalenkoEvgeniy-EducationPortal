using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAsync();
        IEnumerable<TEntity> GetAsync(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
