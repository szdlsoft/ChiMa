using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace SixMan.ChiMa.Application.Food
{
    public class FoodMaterialAppService
        : AsyncCrudAppService<FoodMaterial, FoodMaterialDto, long, PagedResultRequestDto, FoodMaterialDto, FoodMaterialDto>
        , IFoodMaterialAppService

    {
        public FoodMaterialAppService(IRepository<FoodMaterial, long> repository) : base(repository)
        {
        }
    }
}
