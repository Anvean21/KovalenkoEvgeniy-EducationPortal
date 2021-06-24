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
        }

        public bool UniqueCourseName(string name)
        {
            var courseSpecification = new Specification<Course>(x => x.Name.ToLower() == name.ToLower());

            if (courseRepository.FindAsync(courseSpecification).Result == null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<Course> GetCourses(int pageNumber = 1, int itemCount = 10)
        {
            var courseIncludes = new List<Expression<Func<Course, object>>>
            {
                //TODO 
                y => y.Skills
            };

            var courseSpec = new Specification<Course>(x => true, courseIncludes);

            return courseRepository.GetAsync(courseSpec, pageNumber, itemCount).Result.Items;
        }

        public Course GetById(int id)
        {
            var courseIncludes = new List<Expression<Func<Course, object>>>
            {
                y => y.Skills,
                y => y.Materials,
                y => y.Test
            };

            var courseSpec = new Specification<Course>(x => x.Id == id, courseIncludes);

            return courseRepository.FindAsync(courseSpec).Result;
        }
    }
}
