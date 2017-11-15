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
using SixMan.ChiMa.Application.Base;

namespace SixMan.ChiMa.Application.Food
{
    public class FoodMaterialAppService
        : AsyncCrudAppService<FoodMaterial, FoodMaterialDto, long, PagedResultRequestDto, FoodMaterialDto, FoodMaterialDto>
        , IFoodMaterialAppService

    {
        public FoodMaterialAppService(IRepository<FoodMaterial, long> repository) : base(repository)
        {
        }

         public PagedResultDto<FoodMaterialDto> GetFoodMaterials(int offset , int limit )
        {
            var reqestDto = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Description",
                MaxResultCount = limit,
                SkipCount = (offset * limit)
            };
            var result = this.GetAll(reqestDto).Result;
          

            return result;
        }

        public void DeleteList(DeletListDto list)
        {
            var ids = list.Ids.Split(',').Select(id => long.Parse(id));
            ids.ToList().ForEach(id => Repository.Delete(Repository.Get(id)));
        }

    }
}
