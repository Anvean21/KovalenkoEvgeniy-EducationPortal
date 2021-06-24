using AutoMapper;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.ViewModels;
using EducationPortal.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Course, CourseVM>().ReverseMap();
            CreateMap<Test, TestVM>().ReverseMap();
            CreateMap<Question, QuestionVM>().ReverseMap();
            CreateMap<Answer, AnswerVM>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Skill, SkillVM>().ReverseMap();
            CreateMap<Material, MaterialVM>().ReverseMap();
            CreateMap<VideoMaterial, VideoMaterialVM>().ReverseMap();
            CreateMap<BookMaterial, BookMaterialVM>().ReverseMap();
            CreateMap<ArticleMaterial, ArticleMaterialVM>().ReverseMap();
        }
    }
}
