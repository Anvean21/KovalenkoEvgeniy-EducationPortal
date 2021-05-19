using EducationPortal.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal
{
    public static class CustomServiceProvider
    {
        private static IServiceProvider provider;
        public static IServiceProvider Provider
        {
            get
            {
                if (provider == null)
                {
                    provider = DependecyIngection.ConfigureService();
                }
                return provider;
            }
        }
    }
}
