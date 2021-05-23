using AutoMapper;
using EducationPortal.Domain.Core;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public class Map
    {
        public static DestinationType MapVmToDomain<SourceType, DestinationType>(SourceType viewModel)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<SourceType, DestinationType>());
            var mapper = new Mapper(configuration);

            return mapper.Map<SourceType, DestinationType>(viewModel);
        }
        public static Course CourseVmToDomain(CourseVM courseVM)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseVM, Course>();
                cfg.CreateMap<SkillVM, Skill>();
                cfg.CreateMap<MaterialVM, Material>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<CourseVM, Course>(courseVM);
        }
    }
}
