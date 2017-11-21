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
using SixMan.ChiMa.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace SixMan.ChiMa.Application.Food
{
    public class FoodMaterialAppService
       : AdvancedAsyncCrudAppService<FoodMaterial, FoodMaterialDto>
        , IFoodMaterialAppService

    {
        public FoodMaterialAppService(IRepository<FoodMaterial, long> repository) : base(repository)
        {
        }

        protected override IQueryable<FoodMaterial> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            if (input.Search.IsNotNullOrEmpty())
            {
                query = from c in query
                        where EF.Functions.Like(c.Description, $"%{input.Search}%")
                        select c;
            }

            return query;
        }

    }
}
