using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    /// <summary>
    ///При переходе на EF переопределить Seed и унаследовать : DropCreateDatabaseIfModelChanges<DbContext>
    /// </summary>
    public class EducationPortalDbInitializer
    {
         //Cоздание бд
        public static void Initialize(EducationContext db)
        {
            Role adminRole = new Role {Id = 1, Name = "admin" };
            Role userRole = new Role {Id = 2, Name = "user" };

            User testAdmin = new User {Id = 1, UserName = "Admin", Email = "Admin@email.com", Password = "AdminPassword", Role = adminRole, RoleId = adminRole.Id };
            User testUser = new User {Id = 2, UserName = "User", Email = "User@email.com", Password = "userPassword", Role = userRole, RoleId = userRole.Id };

            db.Users.Add(testAdmin);
            db.Users.Add(testUser);

            JsonSave(testAdmin);
            JsonSave(testUser);

        }


        //Аdd метод в репозиторий
        //При переезде на EF вынести куда-то
        public static void JsonSave(User user)
        {
            using (FileStream fileStream = new FileStream(@"D:\Users", FileMode.Append))
            {
                //Перезаписывает юзеров, а не добавляет
                 JsonSerializer.SerializeAsync<User>(fileStream, user);
                Console.WriteLine("Пользователь успешно добавлен в файл");
            }
        }
    }


}

