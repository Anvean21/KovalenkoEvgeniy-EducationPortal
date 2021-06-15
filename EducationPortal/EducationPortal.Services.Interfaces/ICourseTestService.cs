using EducationPortal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface ICourseTestService
    {
        public void AddTest(Test test);
        public int CountResult(Question question, string userVariant, ref int result);
        public Test GetTest(string name);
    }
}
