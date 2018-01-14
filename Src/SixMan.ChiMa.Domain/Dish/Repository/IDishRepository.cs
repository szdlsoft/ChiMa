using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    public interface IDishRepository
        :  IRepository<Dish, long>
    {
        Dish GetWithDetails(long id);
    }
}
