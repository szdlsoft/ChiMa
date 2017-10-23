using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialCategoryAppService 
        : IAsyncCrudAppService<FoodMaterialCategoryDto, long, PagedResultRequestDto, FoodMaterialCategoryDto, FoodMaterialCategoryDto>
    {
    }
}
