using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Food;
using SixMan.UICommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialCategoryAppService 
        : IAdvancedAsyncCrudAppService<FoodMaterialCategoryDto>
        , IInitCreate<FoodMaterialCategoryDto>
    {
        //FoodMaterialCategoryDto Add();
        //void DeleteList(DeletListDto list);
    }
}
