using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Application.Extensions;
using SixMan.ChiMa.Application.Base;
using System.Linq;

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

        public FoodMaterialCategoryDto Add()
        {
            return Repository.Insert(new FoodMaterialCategory())
                        .ToDto<FoodMaterialCategory, FoodMaterialCategoryDto>();
        }

        public void DeleteList(DeletListDto list)
        {
            var ids = list.Ids.Split(',').Select(id => long.Parse(id));
            ids.ToList().ForEach(id => Repository.Delete(Repository.Get(id)));
        }
    }
}
