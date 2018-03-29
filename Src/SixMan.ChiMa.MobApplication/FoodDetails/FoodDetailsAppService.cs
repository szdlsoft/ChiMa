using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Web.Models;

namespace SixMan.ChiMa.Application
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    [Abp.Authorization.AbpAuthorize]
    public class FoodDetailsAppService
        : MobileAppServiceBase<FoodMaterial, MobFoodMaterialDto>
        , IFoodDetailsAppService
    {
        public FoodDetailsAppService(IRepository<FoodMaterial, long> repository) : base(repository)
        {
        }

        public IList<MobFoodMaterialDto> GetSeasons()
        {
            return Repository.GetAll()
                             .Take(1)
                             .Select(MapToEntityDto)
                             .ToList();
        }
    }
}
