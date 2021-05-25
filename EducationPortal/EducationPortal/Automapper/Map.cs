﻿using AutoMapper;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.ViewModels;
using EducationPortal.ViewModels.TestViewModels;

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
                cfg.CreateMap<TestVM, Test>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<CourseVM, Course>(courseVM);
        }

        public static Test TestVmToDomain(TestVM testVM)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestVM, Test>();
                cfg.CreateMap<QuestionVM, Question>();
                cfg.CreateMap<AnswerVM, Answer>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<TestVM, Test>(testVM);
        }
    }
}
