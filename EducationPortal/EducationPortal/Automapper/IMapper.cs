using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public interface IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;

        public IEnumerable<TDestination> Map<TSourse, TDestination>(IEnumerable<TSourse> sources)
            where TSourse : class
            where TDestination : class;
    }
}
