using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            courseRepository.AddAsync(course);
            courseRepository.SaveAsync();
        }

        public IEnumerable<Course> GetCourses(int pageNumber = 1, int itemCount = 10)
        {
            var skillIncludes = new List<Expression<Func<Course, object>>>
            {
                y => y.Skills
            };
            var courseSpec = new Specification<Course>(x => x.Id == x.Id, skillIncludes);

            return courseRepository.GetAsync(courseSpec, pageNumber, itemCount).Result.Items;
        }

        public Course GetById(int id)
        {
            return courseRepository.FindAsync(id).Result;
        }
    }
}
