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
using SixMan.ChiMa.Domain.Food.Repository;
using SixMan.ChiMa.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;

namespace SixMan.ChiMa.Application.Food
{
    [AbpAuthorize]
    public class FoodMaterialCategoryAppService
        : AdvancedAsyncCrudAppService<FoodMaterialCategory, FoodMaterialCategoryDto>
        , IFoodMaterialCategoryAppService
    {
        public FoodMaterialCategoryAppService(IRepository<FoodMaterialCategory, long> repository) 
            : base(repository)
        {

        }

        protected override IQueryable<FoodMaterialCategory> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            if (input.Search.IsNotNullOrEmpty())
            {
                query = from c in query
                        where EF.Functions.Like(c.Name, $"%{input.Search}%")
                        select c;
            }

            return query;
        }

        protected override int ImportRow(Dictionary<string, string> row)
        {
            return 0;
        }
    }
}
