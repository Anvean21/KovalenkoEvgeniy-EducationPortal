using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Helpers
{
    public class Map
    {
        public static DM MapVmToDomain<VM,DM>(VM viewModel)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<VM, DM>());
            var mapper = new Mapper(configuration);

            return mapper.Map<VM, DM>(viewModel);
        } 
    }
}
