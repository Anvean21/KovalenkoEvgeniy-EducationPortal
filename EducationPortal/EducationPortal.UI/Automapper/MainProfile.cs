using AutoMapper;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.UI.Models;
using EducationPortal.UI.Models.TestViewModels;

namespace EducationPortal.UI.Automapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Course, CourseVM>().ReverseMap();
            CreateMap<Test, TestVM>().ForMember(x=> x.Result, (options) => options.Ignore()).ReverseMap();
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
