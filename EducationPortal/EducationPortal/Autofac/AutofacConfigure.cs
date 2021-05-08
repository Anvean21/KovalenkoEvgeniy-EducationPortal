using Autofac;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Autofac
{
    class AutofacConfigure
    {
        public static void ConfigureContainer()
        {
           //Перенести зависимости сюда, когда перейдем на Core. Сейчас зависимости прямо в Main();
        }
    }
}
