using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EducationPortal.Domain.Core;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CourseVM, Course>();
        }
    }
}
