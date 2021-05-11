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
            if (userRepository.GetAll().Any(x=>x.Email == model.Email))
            {
                return false;
            }
            else
            {
                userRepository.Create(model);
                return true;
            }
        }

        public IEnumerable<User> UsersList()
        {
            return userRepository.GetAll();
        }
    }
}
