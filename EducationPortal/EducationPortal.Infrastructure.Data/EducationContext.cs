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

        //Аля DbSet, только не рабочий..
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        //Чтобы при обращению к контексту создавалась БД
        static EducationContext()
        {
            EducationPortalDbInitializer.Initialize(new EducationContext());
        }

        //Заготовка под EF
        //static EducationContext()
        //{
        //    Database.SetInitializer(new EducationPortalDbInitializer());
        //}
        //public EducationContext(string connectionString)
        //    : base(connectionString)
        //{
        //}
    }
}
