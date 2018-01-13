using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SixMan.ChiMa.EFCore.Repositories
{
    public class PlanRepository
        : ChiMaRepositoryBase<Plan, long>
          , IPlanRepository
    {
        public PlanRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public IList<Plan> Get(DateTime planDate, long familyId)
        {
            var q = GetAll()
                    .Include(p => p.Family)
                    .Include(p => p.Dish)
                    .ThenInclude(d => d.UserComments)
                    .Include(p => p.Dish)
                    .ThenInclude(d => d.UserUserFavorites )
                    .Where(p => p.Family.Id == familyId
                             && p.PlanDate == planDate  )
                    ;
            var result = q.ToList();
            return result;
        }
    }
}
