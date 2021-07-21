using EducationPortal.Domain.Core;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Automapper
{
    public class EntityMapper : IMapper
    {
        readonly AutoMapper.IMapper mapper;

        public EntityMapper(AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            switch (source)
            {
                case Material _:
                case MaterialVM _:

                    var entity = this.mapper.ConfigurationProvider.GetAllTypeMaps().First(x => x.SourceType == source.GetType()).DestinationType;

                    return this.mapper.Map(source, source.GetType(), entity) as TDestination;

                default: return this.mapper.Map<TDestination>(source);
            }
        }

        public IEnumerable<TDestination> Map<TSourse, TDestination>(IEnumerable<TSourse> sources)
            where TSourse : class
            where TDestination : class
        {
            switch (sources)
            {
                case Material _:
                case MaterialVM _:

                    var entities = new List<TDestination>();

                    foreach (var entity in sources)
                    {
                        entities.Add(this.Map<TSourse, TDestination>(entity));
                    }

                    return entities;

                default: return this.mapper.Map<IEnumerable<TDestination>>(sources);
            }
        }
    }
}
