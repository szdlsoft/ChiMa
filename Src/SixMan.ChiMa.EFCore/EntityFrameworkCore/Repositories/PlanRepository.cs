using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;

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

        public IList<FoodMaterialVolume> GetByRange(long familyId, DateRange dateRange)
        {
            List<FoodMaterialVolume> planNeeds = new List<FoodMaterialVolume>();
            var q = GetAllIncluding(p => p.Family
                                    , p => p.Dish
                                    , p => p.Dish.DishBoms)
                    .Where(p => p.Family.Id == familyId
                        && p.PlanDate >= dateRange.From
                        && p.PlanDate <= dateRange.To);
                    
            var planList = q.ToList();
            foreach ( var p in planList)
            {
                var d = p.Dish;
                if (d.DishBoms == null) continue;
                foreach( var db in d.DishBoms)
                {
                    var fmv = planNeeds.FirstOrDefault(pn => pn.FoodMaterial.Id == db.FoodMaterialId);
                    if( fmv == null)
                    {
                        var  fm = Context.FoodMaterial.Find(db.FoodMaterialId);
                        planNeeds.Add(new FoodMaterialVolume() {
                            FoodMaterial = fm,
                            Volume = (int)(db.Matching * 100) //暂时写死
                        }
                            );
                    }
                    else
                    {
                        fmv.Volume += (int)(db.Matching * 100); //暂时写死
                    }
                }

            }
            return planNeeds;
        }
    }
}
