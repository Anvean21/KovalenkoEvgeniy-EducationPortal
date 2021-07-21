using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities.RelationModels;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task Register(User model)
        {
            model.Password = passwordHasher.HashPassword(model.Password);
            await userRepository.AddAsync(model);
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

        public async Task<bool> GetUniqueEmail(string email)
        {
            var userSpecification = new Specification<User>(x => x.Email.ToLower() == email.ToLower());

            if (await userRepository.FindAsync(userSpecification) == null)
            {
                return true;
            }

            return false;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var includes = new List<Expression<Func<User, object>>>
            {
                y => y.CoursesInProgress,
                y => y.PassedCourses,
                y => y.UserSkills,
                y => y.CreatedCourses
            };
            var userSpecification = new Specification<User>(x => x.Email.ToLower() == email.ToLower(), includes);

            return await userRepository.FindAsync(userSpecification);
        }

        public async Task<bool> AddCourseToProgress(User user, Course course)
        {
            if (user.PassedCourses.Any(x => x.CourseId == course.Id))
            {
                return false;
            }

            if (user.CoursesInProgress.Any(x => x.CourseId == course.Id))
            {
                return true;
            }

            user.CoursesInProgress.Add(new UserCoursesInProgress { UserId = user.Id, CourseId = course.Id });

            await userRepository.Update(user);
            return true;

        }

        public async Task<bool> IsCoursePassed(User user, Course course, int rightAnswers)
        {
            const double minimumRightAnswersPercent = 0.70;

            var countOfQuestions = course.Test.Questions.Count();

            if (countOfQuestions * minimumRightAnswersPercent <= rightAnswers)
            {
                user.PassedCourses.Add(new UserPassedCourses { UserId = user.Id, CourseId = course.Id });

                foreach (var skill in course.Skills)
                {
                    if (UserSkillUp(user, skill))
                    {
                        continue;
                    }
                    else
                    {
                        user.UserSkills.Add(new UserSkills { SkillId = skill.Id, UserId = user.Id });
                    }
                }

                var removedCourse = user.CoursesInProgress.FirstOrDefault(x => x.CourseId == course.Id);

                user.CoursesInProgress.Remove(removedCourse);

                await userRepository.Update(user);

                return true;
            }

            return false;
        }

        private bool UserSkillUp(User user, Skill skill)
        {
            if (user.UserSkills.Any(x => x.SkillId == skill.Id))
            {
                user.UserSkills.FirstOrDefault(x => x.SkillId == skill.Id).Level++;
                return true;
            }

            return false;
        }
    }
}
