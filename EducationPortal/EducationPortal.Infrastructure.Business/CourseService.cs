using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Material> materialRepository;
        private readonly IRepository<Skill> skillRepository;
        private readonly IRepository<Test> testRepository;

        public CourseService(IRepository<Course> courseRepository, IRepository<Material> materialRepository, IRepository<Skill> skillRepository, IRepository<Test> testRepository)
        {
            this.courseRepository = courseRepository;
            this.materialRepository = materialRepository;
            this.skillRepository = skillRepository;
            this.testRepository = testRepository;
        }

        public async Task AddCourse(Course course)
        {
            await courseRepository.AddAsync(course);
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
                y => y.Skills
            };

            var courseSpec = new Specification<Course>(x => x.Created == true, courseIncludes);

            return courseRepository.GetAsync(courseSpec, pageNumber, itemCount).Result.Items;
        }

        public async Task<Course> GetById(int id)
        {
            var courseIncludes = new List<Expression<Func<Course, object>>>
            {
                y => y.Skills,
                y => y.Materials,
                y => y.Test
            };

            var courseSpec = new Specification<Course>(x => x.Id == id, courseIncludes);

            return await courseRepository.FindAsync(courseSpec);
        }

        public async Task AddMaterials(int courseId, int materialId)
        {
            var course = await GetById(courseId);
            course.Materials.Add(materialRepository.FindAsync(materialId).Result);
            await courseRepository.SaveAsync();
        }

        public async Task AddSkills(int courseId, int skillId)
        {
            var course = await GetById(courseId);
            course.Skills.Add(skillRepository.FindAsync(skillId).Result);
            await courseRepository.SaveAsync();
        }

        public async Task<bool> AddTest(int courseId, int testId)
        {
            var course = await GetById(courseId);
            var courseSpec = new Specification<Course>(x => x.TestId == testId);
            var IsTestAlreadyBusy = await courseRepository.FindAsync(courseSpec);
            if (IsTestAlreadyBusy == null)
            {
                course.TestId = testRepository.FindAsync(testId).Result.Id;
                course.Created = true;
                await courseRepository.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
