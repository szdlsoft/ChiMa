using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    public interface IPlanAppService
        : IAdvancedAsyncCrudAppService<PlanDto>
    {
        IList<PlanDto> GetGetPlans(DateTime planDate);
    }
}
