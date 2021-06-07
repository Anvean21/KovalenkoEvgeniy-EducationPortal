using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            userRepository.Create(model);
            authorizedUser = model;
        }

        public bool LogIn(string email, string password)
        {
            var userFromDb = userRepository.GetAll().FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
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
        public bool UserSaveChanges(User user)
        {
            authorizedUser.Skills = user.Skills ?? authorizedUser.Skills;
            authorizedUser.CourseInProgress = user.CourseInProgress;
            authorizedUser.Courses = user.Courses ?? authorizedUser.Courses;
            userRepository.Update(authorizedUser);
            return true;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }
        public bool AddCourseToProgress(Course course)
        {
            if (authorizedUser.Courses.Any(x => x.Name == course.Name))
            {
                return false;
            }
            authorizedUser.CourseInProgress.Add(course);
            UserSaveChanges(authorizedUser);
            return true;
        }
        public bool IsCoursePassed(Course course, int rightAnswers)
        {
            var countOfQuestions = course.Test.Questions.Count();
            if (countOfQuestions * 0.70 <= rightAnswers)
            {
                authorizedUser.Courses.Add(course);
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

                authorizedUser.CourseInProgress.Remove(authorizedUser.CourseInProgress.FirstOrDefault(x => x.Name == course.Name));
                UserSaveChanges(authorizedUser);
                return true;
            }
            return false;
        }
        public bool UserSkillUp(Skill skill)
        {
            if (authorizedUser.Skills.Any(x => x.Name == skill.Name))
            {
                authorizedUser.Skills.FirstOrDefault(x => x.Name == skill.Name).Level++;
                UserSaveChanges(authorizedUser);
                return true;
            }
            return false;
        }
    }
}
