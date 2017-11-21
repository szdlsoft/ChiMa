﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialAppService
        : IAdvancedAsyncCrudAppService<FoodMaterialDto>
    { 
                //: IAsyncCrudAppService<FoodMaterialDto, long, PagedResultRequestDto, FoodMaterialDto, FoodMaterialDto>

    //{
    //    PagedResultDto<FoodMaterialDto> GetFoodMaterials(int offset , int limit );
    //    void DeleteList(DeletListDto list);
    }
}
