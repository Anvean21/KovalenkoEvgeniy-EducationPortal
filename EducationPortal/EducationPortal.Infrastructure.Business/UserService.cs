using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
  public class UserService: IUserService
    {
        private readonly IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Register(User model)
        {
            if (userRepository.GetAll().Any(x=>x.Email.ToLower() == model.Email.ToLower()))
            {
                return false;
            }
            else
            {
                userRepository.Create(model);
                return true;
            }
        }
        public bool LogIn(string email,string password)
        {
            var dbUser = userRepository.GetAll().FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            if (dbUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> UsersList()
        {
            return userRepository.GetAll();
        }
    }
}
