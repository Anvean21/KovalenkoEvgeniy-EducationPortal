using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities.RelationModels;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Infrastructure.Business
{
    public class UserService : IUserService
    {

        private static User authorizedUser;

        private readonly IRepository<User> userRepository;
        private readonly IPasswordHasher passwordHasher;
        public UserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public void Register(User model)
        {
            model.Password = passwordHasher.HashPassword(model.Password);
            userRepository.AddAsync(model);
            authorizedUser = model;
        }

        public bool LogIn(string email, string password)
        {
            var userSpecification = new Specification<User>(x => x.Email.ToLower() == email.ToLower());

            var userFromDb = userRepository.FindAsync(userSpecification).Result;

            if (userFromDb == null)
            {
                return false;
            }
            var res = passwordHasher.VerifyHashedPassword(userFromDb.Password, password);

            if (res == PasswordVerificationResult.Success)
            {
                authorizedUser = userFromDb;
                return true;
            }

            return false;
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

            if (authorizedUser.CoursesInProgress.Any(x => x.CourseId == course.Id))
            {

                return true;
            }

            authorizedUser.CoursesInProgress.Add(new UserCoursesInProgress { UserId = authorizedUser.Id, CourseId = course.Id });

            userRepository.Update(authorizedUser);
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
                        authorizedUser.UserSkills.Add(new UserSkills { SkillId = skill.Id, UserId = authorizedUser.Id });
                    }
                }

                var removedCourse = authorizedUser.CoursesInProgress.FirstOrDefault(x => x.CourseId == course.Id);

                authorizedUser.CoursesInProgress.Remove(removedCourse);

                userRepository.Update(authorizedUser);

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
