using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Data
{
    public class DbContext
    {
        //типо контекст EF
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        //Чтобы при обращению к контексту создавалась БД
        static DbContext()
        {
            EducationPortalDbInitializer initializer = new EducationPortalDbInitializer();
            initializer.Initialize(new DbContext());
        }
    }
}
