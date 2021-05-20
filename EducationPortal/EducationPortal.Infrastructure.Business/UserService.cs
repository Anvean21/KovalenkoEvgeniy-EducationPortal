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
            if (!userRepository.GetAll().Any(x => x.Email.ToLower() == model.Email.ToLower()))
            {
                userRepository.Create(model);
                authorizedUser = model;
            }
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
    }
}
