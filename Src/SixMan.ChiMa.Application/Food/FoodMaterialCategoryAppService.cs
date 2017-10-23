using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;

namespace SixMan.ChiMa.Application.Food
{
    public class FoodMaterialCategoryAppService
        : AsyncCrudAppService<FoodMaterialCategory, FoodMaterialCategoryDto, long, PagedResultRequestDto, FoodMaterialCategoryDto, FoodMaterialCategoryDto>
        , IFoodMaterialCategoryAppService
    {
        public FoodMaterialCategoryAppService(IRepository<FoodMaterialCategory, long> repository) 
            : base(repository)
        {
        }
    }
}
