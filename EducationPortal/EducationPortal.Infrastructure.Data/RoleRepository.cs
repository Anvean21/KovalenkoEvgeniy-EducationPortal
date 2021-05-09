using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    class RoleRepository : IRepository<Role>
    {
        private readonly EducationContext db;

        public RoleRepository(EducationContext context)
        {
            db = context;
        }
        public void Create(Role user)
        {

            db.Roles.Add(user);
        }

        public void Delete(int id)
        {
            Role role = db.Roles.Find(x => x.Id == id);
            if (role != null)
            {
                db.Roles.Remove(role);
            }
        }

        public Role Get(int id)
        {
            return db.Roles.Find(x => x.Id == id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public void Save(Role item)
        {
            JsonFileOperations<Role> json = new JsonFileOperations<Role>();
            json.JsonSave(item);
        }

        //Расскоментить EF
        //public void Update(Role role)
        //{
        //    db.Entry(role).State = System.Data.Entity.EntityState.Modified;
        //}
    }
}
