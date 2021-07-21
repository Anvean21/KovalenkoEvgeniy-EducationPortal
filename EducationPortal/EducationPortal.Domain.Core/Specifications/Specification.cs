using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EFlecture.Core.Specifications
{
    public class Specification<TEntity>
        where TEntity : BasicEntity
    {
        public Expression<Func<TEntity, bool>> Expression { get; }
        public List<Expression<Func<TEntity, object>>> Include { get; }

        public Func<TEntity, bool> Func => this.Expression.Compile();

        public Specification(Expression<Func<TEntity, bool>> expression, List<Expression<Func<TEntity, object>>> include = default)
        {
            this.Expression = expression;
            this.Include = include;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return this.Func(entity);
        }
    }
}
