using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Infrastructure.Business
{
    public class UserService : IUserService
    {

        private static User authorizedUser;

        private readonly IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(User model)
        {
            userRepository.AddAsync(model);
            authorizedUser = model;
        }

        public bool LogIn(string email, string password)
        {
            var userSpecification = new Specification<User>(x => x.Email.ToLower() == email.ToLower() && x.Password == password);

            var userFromDb = userRepository.FindAsync(userSpecification).Result;

            if (userFromDb == null)
            {
                return false;
            }

            authorizedUser = userFromDb;
            return true;
        }

        public bool LogOut()
        {
            authorizedUser = null;
            return true;
        }

        public bool IsUserAuthorized()
        {
            if (authorizedUser != null)
            {
                return true;
            }
            return false;
        }

        public bool GetUniqueEmail(string email)
        {
            var userSpecification = new Specification<User>(x => x.Email.ToLower() == email.ToLower());

            if (userRepository.FindAsync(userSpecification).Result == null)
            {
                return true;
            }

            return false;
        }

        public bool AddCourseToProgress(Course course)
        {
            if (authorizedUser.PassedCourses.Any(x => x.Id == course.Id))
            {
                return false;
            }

            if (authorizedUser.CourseInProgress.Any(x => x.Id == course.Id))
            {

                return true;
            }

            authorizedUser.CourseInProgress.Add(course);

            userRepository.Update(authorizedUser);
            userRepository.SaveAsync();
            return true;

        }

        public bool IsCoursePassed(Course course, int rightAnswers)
        {
            const double minimumRightAnswersPercent = 0.70;

            var countOfQuestions = course.Test.Questions.Count();

            if (countOfQuestions * minimumRightAnswersPercent <= rightAnswers)
            {
                authorizedUser.PassedCourses.Add(course);

                foreach (var skill in course.Skills)
                {
                    if (UserSkillUp(skill))
                    {
                        continue;
                    }
                    else
                    {
                        authorizedUser.Skills.Add(skill);
                    }
                }

                var removedCourse = authorizedUser.CourseInProgress.FirstOrDefault(x => x.Id == course.Id);

                authorizedUser.CourseInProgress.Remove(removedCourse);

                userRepository.Update(authorizedUser);
                userRepository.SaveAsync();

                return true;
            }

            return false;
        }

        public bool UserSkillUp(Skill skill)
        {
            if (authorizedUser.Skills.Any(x => x.Id == skill.Id))
            {
                authorizedUser.Skills.FirstOrDefault(x => x.Id == skill.Id).Level++;
                return true;
            }

            return false;
        }
    }
}
