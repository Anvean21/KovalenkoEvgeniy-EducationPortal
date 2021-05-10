using EducationPortal.Domain.Core;
using EducationPortal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal
{
   public class UserController
    {
        EFUnitOfWork unitOfWork = new EFUnitOfWork();
        public void UserList()
        {
            foreach (var user in unitOfWork.Users.GetAll())
            {
                Console.WriteLine($"Id - {user.Id} Имя - {user.UserName}, Email - {user.Email}, Role - {user.Role.Name}");
            }
        }
        public void Register(User model)
        {

            User user = unitOfWork.Users.GetAll().FirstOrDefault(u => u.Email == model.Email);
            Role role = new Role();
            role.Name = "user";
            role.Id = 2;
            int maxId = unitOfWork.Users.GetAll().Count();
            if (user == null)
            {
                unitOfWork.Users.Create(new User {Id = ++maxId, UserName = model.UserName, Password = model.Password, Email = model.Email, Role = role});
                Console.WriteLine("Вы успешно зарегистрированы");
            }
            else
            {
                throw new Exception("Пользователь с таким Email уже зарегестрирован");
            }

        }
    }
}
