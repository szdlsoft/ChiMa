using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Family;

namespace SixMan.ChiMa.Application.Family
{
    public interface IFamilyAppService
    : IAdvancedAsyncCrudAppService<FamilyDto>
    {
        Domain.Family.Family GetOrCreate();
    }
}
