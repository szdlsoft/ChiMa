using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Dish
{
    public interface IDishAppService
        : IAdvancedAsyncCrudAppService<DishDto>
        , IImportFromExcel
    {
       
    }
}
