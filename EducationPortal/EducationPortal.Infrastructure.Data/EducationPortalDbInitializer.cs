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
        public static void Initialize(JsonFileOperations<User> save)
        {
            Role adminRole = new Role {Id = 1, Name = "admin" };
            Role userRole = new Role {Id = 2, Name = "user" };

            User testAdmin = new User {Id = 1, UserName = "Admin", Email = "Admin@email.com", Password = "AdminPassword", Role = adminRole, RoleId = adminRole.Id };
            User testUser = new User {Id = 2, UserName = "User", Email = "User@email.com", Password = "userPassword", Role = userRole, RoleId = userRole.Id };
            User testModer = new User { Id = 3, UserName = "Moder", Email = "Moder@email.com", Password = "ModerPassword", Role = adminRole, RoleId = adminRole.Id };


            //Это нужно расскоментировать для запуска из коробки. После того как программа отработает надо вернуть всё обратно.

            //List<User> list = new List<User>();
            //list.Add(testModer);
            //list.Add(testUser);
            //list.Add(testAdmin);
            //save.JsonSave(list, @"D:\Users.json");

        }
    }
}

