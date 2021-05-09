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
        public static void Initialize(JsonFileOperations<User> db)
        {
            Role adminRole = new Role {Id = 1, Name = "admin" };
            Role userRole = new Role {Id = 2, Name = "user" };

            User testAdmin = new User {Id = 1, UserName = "Admin", Email = "Admin@email.com", Password = "AdminPassword", Role = adminRole, RoleId = adminRole.Id };
            User testUser = new User {Id = 2, UserName = "User", Email = "User@email.com", Password = "userPassword", Role = userRole, RoleId = userRole.Id };

            db.JsonSave(testUser);
            db.JsonSave(testAdmin);
        }
    }
}

