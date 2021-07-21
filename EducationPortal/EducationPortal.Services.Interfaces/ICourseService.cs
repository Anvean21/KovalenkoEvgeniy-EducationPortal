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
        public Task<Course> GetById(int id);
        public Task<Course> GetByTestId(int testId);
        public Task<bool> UniqueCourseName(string name);
        public Task AddMaterials(int courseId, int materialId);
        public Task AddSkills(int courseId, int skillId);
        public Task<bool> AddTest(int courseId, int testId);
    }
}
