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

        public UserRepository(EducationContext context)
        {
            db = context;
        }
        public void Create(User user)
        {
            
            db.Users.Add(user);
            //записываем в базу
            EducationPortalDbInitializer.JsonSave(user);
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
            return db.Users.Find(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        //Расскоментить EF
        //public void Update(User user)
        //{
        //    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //}
    }
}
