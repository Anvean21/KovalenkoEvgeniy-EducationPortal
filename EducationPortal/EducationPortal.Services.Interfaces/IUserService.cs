using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface IUserService
    {
        public Task Register(User model);
        public bool LogIn(string login, string password);
        public bool LogOut();
        public bool IsUserAuthorized();
        public Task<bool> AddCourseToProgress(User user,Course course);
        public bool IsCoursePassed(Course course, int result);
        public bool UserSkillUp(Skill skill);
        public bool GetUniqueEmail(string email);
        public Task<User> GetUserByEmail(string email);
    }
}
