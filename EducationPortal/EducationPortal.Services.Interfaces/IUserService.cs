using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
   public interface IUserService
    {
        public IEnumerable<User> UsersList();
        public bool Register(User model);

    }
}
