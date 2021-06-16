using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities.RelationModels;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
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
            userRepository.AddAsync(model);
            userRepository.SaveAsync();
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
            if (authorizedUser.PassedCourses.Any(x => x.CourseId == course.Id))
            {
                return false;
            }

            if (authorizedUser.CourseInProgress.Any(x => x.CourseId == course.Id))
            {

                return true;
            }

            authorizedUser.CourseInProgress.Add(new UserCoursesInProgress { UserId = authorizedUser.Id, CourseId = course.Id });

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
                authorizedUser.PassedCourses.Add(new UserPassedCourses { UserId = authorizedUser.Id, User = authorizedUser });

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

                var removedCourse = authorizedUser.CourseInProgress.FirstOrDefault(x => x.CourseId == course.Id);

                authorizedUser.CourseInProgress.Remove(removedCourse);

                userRepository.Update(authorizedUser);
                userRepository.SaveAsync();

                return true;
            }

            return false;
        }

        public bool UserSkillUp(Skill skill)
        {
            if (authorizedUser.UserSkills.Any(x => x.SkillId == skill.Id))
            {
                authorizedUser.UserSkills.FirstOrDefault(x => x.SkillId == skill.Id).Level++;
                return true;
            }

            return false;
        }
    }
}
