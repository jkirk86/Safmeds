using AutoMapper;
using Safmeds.Repository.Models;
using Safmeds.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safmeds.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Safmed, SafmedViewModel>();
            Mapper.CreateMap<SafmedViewModel, Safmed>();
            Mapper.CreateMap<SafmedSession, SafmedSessionViewModel>();
            Mapper.CreateMap<SafmedSessionViewModel, SafmedSession>();
        }
    }
}