using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    public class EFUnitOfWork : IUnitOfWork
    {

       private readonly EducationContext db = new EducationContext();
        private UserRepository userRepository;
        private RoleRepository roleRepository;

        //На будущее
        //public UnitOfWork(string connectionString)
        //{
        //    db = new DbContext(connectionString);
        //}
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new RoleRepository(db);
                }
                return roleRepository;
            }
        }

        //Реализовать
        public void Dispose()
        {
            //...
            throw new NotImplementedException();
        }
    }
}
