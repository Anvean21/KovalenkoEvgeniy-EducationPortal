using EducationPortal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface ICourseTestService
    {
        public void AddTest(Test test);
        public int CountResult(Question question, string userVariant, ref int result);
        public Task<Test> GetTestById(int Id);
        public Task<Test> GetTestByName(string name);
        public bool UniqueTestName(string uniqeItem);
    }
}
