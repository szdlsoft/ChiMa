using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialCategoryAppService 
        : IAsyncCrudAppService<FoodMaterialCategoryDto, long, PagedResultRequestDto, FoodMaterialCategoryDto, FoodMaterialCategoryDto>
    {
        FoodMaterialCategoryDto Add();
        void DeleteList(DeletListDto list);
    }
}
