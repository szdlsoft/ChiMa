using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Base;

namespace SixMan.ChiMa.Domain.Dish
{
    public interface IPlanRepository
        : IRepository<Plan, long>
    {
        IList<Plan> Get(DateTime planDate, long familyId);
        IList<FoodMaterialVolume> GetByRange(long id, DateRange dateRange);
    }
}
