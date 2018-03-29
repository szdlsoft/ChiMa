using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Food.Repository;
using SixMan.ChiMa.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Repositories
{
    public class FoodMaterialCategoryRepository
        : ChiMaRepositoryBase<FoodMaterialCategory, long>
        , IFoodMaterialCategoryRepository
    {
        public FoodMaterialCategoryRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public FoodMaterialCategory InsertWithId(FoodMaterialCategory newEntiry)
        {
            var id = InsertAndGetId(newEntiry);
            newEntiry.Id = id;
            return newEntiry;
        }
    }
}
