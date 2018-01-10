using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;

namespace SixMan.ChiMa.EFCore.Repositories
{
    public class PlanRepository
        : ChiMaRepositoryBase<Plan, long>
          , IPlanRepository
    {
        protected PlanRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public IList<Plan> Get(DateTime planDate, long id)
        {
            throw new NotImplementedException();
        }
    }
}
