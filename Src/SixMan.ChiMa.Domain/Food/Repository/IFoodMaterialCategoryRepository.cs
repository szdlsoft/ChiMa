using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Food.Repository
{
    public interface IFoodMaterialCategoryRepository
        : IRepository<FoodMaterialCategory, long>
    {
        FoodMaterialCategory InsertWithId(FoodMaterialCategory newEntiry);
    }
}
