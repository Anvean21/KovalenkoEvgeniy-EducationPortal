using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface ICourseService
    {
        public Task AddCourse(Course course);
        public IEnumerable<Course> GetCourses(int pageNumber = 1, int itemCount = 10);
        public Course GetById(int id);
        public bool UniqueCourseName(string name);
    }
}
