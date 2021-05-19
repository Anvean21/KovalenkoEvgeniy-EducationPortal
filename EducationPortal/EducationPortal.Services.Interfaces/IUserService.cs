using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IUserService
    {
        public bool Register(User model);
        public bool LogIn(string email, string password);
    }
}
