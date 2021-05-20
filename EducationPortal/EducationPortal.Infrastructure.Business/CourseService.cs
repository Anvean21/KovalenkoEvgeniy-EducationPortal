using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> courseRepository;
        private IRepository<Skill> skillRepository;
        private IRepository<Material> materialRepository;
        // убрать лишние репосы, имплемантация интерфейса
        public CourseService(IRepository<Course> courseRepository, IRepository<Skill> skillRepository, IRepository<Material> materialRepository)
        {
            this.courseRepository = courseRepository;
            this.materialRepository = materialRepository;
            this.skillRepository = skillRepository;
        }
        public Course AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        void ICourseService.AddCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
