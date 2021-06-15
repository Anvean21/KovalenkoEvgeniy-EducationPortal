using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IUserService
    {
        public void Register(User model);
        public bool LogIn(string login, string password);
        public bool LogOut();
        public bool IsUserAuthorized();
        public IEnumerable<User> GetUsers(int pageNumber = 1, int itemCount = 10);
        public bool AddCourseToProgress(Course course);
        public bool IsCoursePassed(Course course, int result);
        public bool UserSkillUp(Skill skill);
    }
}
