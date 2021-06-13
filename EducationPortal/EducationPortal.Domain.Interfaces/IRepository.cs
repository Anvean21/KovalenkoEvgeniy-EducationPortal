using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EducationPortal.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Убрать + настроить пагинацию
        IEnumerable<TEntity> GetAsync();
        IEnumerable<TEntity> GetAsync(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
