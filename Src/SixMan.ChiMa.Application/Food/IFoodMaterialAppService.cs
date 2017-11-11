using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialAppService
                : IAsyncCrudAppService<FoodMaterialDto, long, PagedResultRequestDto, FoodMaterialDto, FoodMaterialDto>

    {
    }
}
