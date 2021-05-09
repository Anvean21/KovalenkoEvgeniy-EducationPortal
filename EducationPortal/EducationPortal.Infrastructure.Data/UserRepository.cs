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
        //при переезде на EF изменить это
        public void Save(User user)
        {
            JsonFileOperations<User> json = new JsonFileOperations<User>();
            //json.JsonSave(user, @"D:\users.json");
            //JsonFileOperations<User> json = new JsonFileOperations<User>();
            //json.JsonSave(user, @"D:\Users.json");
        }
        public void Create(User user)
        {
            //db.Users.Add(user);
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
            //IEnumerable<User> list = JsonFileOperations<User>.JsonDeserializer(@"D:\Users.json");
            return list;
        }
        //Расскоментить EF
        //public void Update(User user)
        //{
        //    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //}
    }
}

