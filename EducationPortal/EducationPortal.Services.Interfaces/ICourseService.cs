using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface ICourseService
    {
        public void AddCourse(Course course);
        public IEnumerable<Course> GetCourses(int pageNumber = 1, int itemCount = 10);
        public Course GetById(int id);
    }
}
