using AutoMapper;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.ViewModels;
using EducationPortal.ViewModels.TestViewModels;

namespace EducationPortal.Automapper
{
    public class Map
    {
        public DestinationType MapVmToDomain<SourceType, DestinationType>(SourceType viewModel)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<SourceType, DestinationType>());
            var mapper = new Mapper(configuration);

            return mapper.Map<SourceType, DestinationType>(viewModel);
        }

        public Course CourseVmToDomain(CourseVM courseVM)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseVM, Course>();
                cfg.CreateMap<SkillVM, Skill>();
                cfg.CreateMap<MaterialVM, Material>();
                cfg.CreateMap<TestVM, Test>();
                cfg.CreateMap<QuestionVM, Question>();
                cfg.CreateMap<AnswerVM, Answer>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<CourseVM, Course>(courseVM);
        }
        public CourseVM CourseDomainToVM(Course course)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseVM>();
                cfg.CreateMap<Skill, SkillVM>();
                cfg.CreateMap<Material, MaterialVM>();
                cfg.CreateMap<Test, TestVM>();
                cfg.CreateMap<Question, QuestionVM>();
                cfg.CreateMap<Answer, AnswerVM>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<Course, CourseVM>(course);
        }

        public Test TestVmToDomain(TestVM testVM)
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

        public TestVM TestDomainToVm(Test test)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Test, TestVM>();
                cfg.CreateMap<Question, QuestionVM>();
                cfg.CreateMap<Answer, AnswerVM>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<Test, TestVM>(test);
        }

        public Question QuestionVmToDomain(QuestionVM querstionVM)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionVM, Question>();
                cfg.CreateMap<AnswerVM, Answer>();
            });
            var mapper = new Mapper(configuration);
            return mapper.Map<QuestionVM, Question>(querstionVM);
        }
    }
}
