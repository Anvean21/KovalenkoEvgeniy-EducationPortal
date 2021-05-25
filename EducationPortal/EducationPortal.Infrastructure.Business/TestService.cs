using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> testService;
        public TestService(IRepository<Test> testService)
        {
            this.testService = testService;
        }
        public void AddTest(Test test)
        {
            testService.Create(test);
        }
    }
}
