using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public class Map
    {
        public static TDM MapVmToDomain<TVM,TDM>(TVM viewModel)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TVM, TDM>());
            var mapper = new Mapper(configuration);

            return mapper.Map<TVM, TDM>(viewModel);
        } 
    }
}
