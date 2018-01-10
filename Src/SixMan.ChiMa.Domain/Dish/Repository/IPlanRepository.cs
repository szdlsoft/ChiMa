using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    public interface IPlanRepository
        : IRepository<Plan, long>
    {
        IList<Plan> Get(DateTime planDate, long id);
    }
}
