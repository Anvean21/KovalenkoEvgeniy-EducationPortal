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
        private readonly IRepository<Course> courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            courseRepository.Create(course);
        }

        public IEnumerable<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }
    }
}
