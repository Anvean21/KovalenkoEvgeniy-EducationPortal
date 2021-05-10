using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly EducationContext db;

        public string path = @"D:\users.json";
        public UserRepository(EducationContext context)
        {
            db = context;
        }
        public void Create(User user)
        {
            List<User> users = new List<User>();
            users.Add(user);
            JsonFileOperations<User> save = new JsonFileOperations<User>();
            save.JsonSave(users,path);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(x => x.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public User Get(int id)
        {
            IEnumerable<User> list = JsonFileOperations<User>.JsonDeserializer(path);
            return list.FirstOrDefault(x=> x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            List<User> list = JsonFileOperations<User>.JsonDeserializer(path);
            return list;
        }
    }
}

