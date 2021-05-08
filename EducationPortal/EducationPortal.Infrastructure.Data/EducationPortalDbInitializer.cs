using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class EducationPortalDbInitializer
    {
         //Cоздание бд
        public void Initialize(DbContext db)
        {
            Role adminRole = new Role { Name = "admin" };
            Role userRole = new Role { Name = "user" };

            User testAdmin = new User() { UserName = "Admin", Email = "Admin@email.com", Password = "AdminPassword", Role = adminRole };
            User testUser = new User { UserName = "User", Email = "User@email.com", Password = "userPassword", Role = userRole };

            db.Users.Add(testAdmin);
            db.Users.Add(testUser);
            JsonSave(testAdmin);
            JsonSave(testUser);
        }


        //Аdd метод в репозиторий
        public void JsonSave(User user)
        {
            using (FileStream fileStream = new FileStream(@"D:\Users", FileMode.OpenOrCreate))
            {
                 JsonSerializer.SerializeAsync<User>(fileStream, user);
                Console.WriteLine("Пользователь успешно добавлен в файл");
            }
        }
    }


}

