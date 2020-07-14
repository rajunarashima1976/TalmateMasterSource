using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalmateSourceCode.EntityModel;
using TalmateSourceCode.Models;

namespace TalmateSourceCode.Mappings
{
    public class DemandProfile:Profile
    {
        public DemandProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Demand, DemandDTO>();
        }
    }
}
