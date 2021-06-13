using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities.RelationModels;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var userFromDb = userRepository.GetAsync(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();

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

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAsync();
        }

        public bool AddCourseToProgress(Course course)
        {
            if (authorizedUser.PassedCourses.Any(x => x.Course.Name == course.Name))
            {
                return false;
            }
            authorizedUser.CourseInProgress.Add(new UserCoursesInProgress { UserId = authorizedUser.Id, CourseId = course.Id });
            return true;
        }

        public bool IsCoursePassed(Course course, int rightAnswers)
        {
           const double minimumRightAnswersPercent = 0.70;

            var countOfQuestions = course.Test.Questions.Count();
            if (countOfQuestions * minimumRightAnswersPercent <= rightAnswers)
            {
                authorizedUser.PassedCourses.Add(new UserPassedCourses { UserId = authorizedUser.Id, CourseId = course.Id });
                foreach (var skill in course.Skills)
                {
                    if (UserSkillUp(skill))
                    {
                        continue;
                    }
                    else
                    {
                        authorizedUser.UserSkills.Add(new UserSkills { UserId = authorizedUser.Id, SkillId = skill.Id });
                    }
                }

                authorizedUser.CourseInProgress.Remove(authorizedUser.CourseInProgress.FirstOrDefault(x => x.Course.Name == course.Name));
                return true;
            }
            return false;
        }

        public bool UserSkillUp(Skill skill)
        {
            if (authorizedUser.UserSkills.Any(x => x.Skill.Name == skill.Name))
            {
                authorizedUser.UserSkills.FirstOrDefault(x => x.Skill.Name == skill.Name).Level++;
                return true;
            }
            return false;
        }
    }
}
