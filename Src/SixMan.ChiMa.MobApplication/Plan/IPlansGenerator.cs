using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    public interface IPlansGenerator
        : Abp.Dependency.ISingletonDependency
    {
        IList<Plan> BuildPlans(DateTime planDate, SixMan.ChiMa.Domain.Family.Family family);
        long GetRandomChange(Plan plan);
    }
}
