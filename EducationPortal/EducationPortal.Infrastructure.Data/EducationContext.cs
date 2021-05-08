using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    /// <summary>
    /// Унаcледовать от :DbContext, поменять листы на DbSet-ы
    /// </summary>
    public class EducationContext
    {
        //типо контекст EF
        public List<User> Users { get; set; } = new List<User>();
        public List<Role> Roles { get; set; } = new List<Role>();

        //Чтобы при обращению к контексту создавалась БД
        static EducationContext()
        {
            EducationPortalDbInitializer.Initialize(new EducationContext());
        }

        //Заготовка под EF
        //static DbContext()
        //{
        //    Database.SetInitializer(new EducationPortalDbInitializer());
        //}
        //public DbContext(string connectionString)
        //    : base(connectionString)
        //{
        //}
    }
}
