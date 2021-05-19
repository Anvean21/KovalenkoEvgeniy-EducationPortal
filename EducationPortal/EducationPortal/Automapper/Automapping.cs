using AutoMapper;
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
            CreateMap<UserVM,User>();
        }
        public static DM MapVmToDomain<VM, DM>(VM viewModel)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<VM, DM>());
            var mapper = new Mapper(configuration);

            return mapper.Map<VM, DM>(viewModel);
        }
    }
}
