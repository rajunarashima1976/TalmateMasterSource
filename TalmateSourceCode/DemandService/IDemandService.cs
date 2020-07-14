using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalmateSourceCode.EntityModel;

namespace TalmateSourceCode.DemandService
{
    public interface IDemandService
    {
        Task<IQueryable<Demand>> Get();
        Task<bool> Post(Demand demand);
    }
}
