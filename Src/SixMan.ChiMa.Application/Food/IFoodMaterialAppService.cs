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

namespace SixMan.ChiMa.Application.Food
{
    public interface IFoodMaterialAppService
        : IAdvancedAsyncCrudAppServiceBase<FoodMaterialDto, FoodMateialPagedResultRequestDto, FoodMaterialDto, FoodMaterialDto> 
        , IImportFromExcel
    {
        //: IAsyncCrudAppService<FoodMaterialDto, long, PagedResultRequestDto, FoodMaterialDto, FoodMaterialDto>

        //{
        //    PagedResultDto<FoodMaterialDto> GetFoodMaterials(int offset , int limit );
        //    void DeleteList(DeletListDto list);
        //int Import(List<Dictionary<string, string>> importData);
        //Task<PagedResultDto<FoodMaterialDto>> GetList(FoodMateialPagedResultRequestDto input);
        void CreatOrUpdate(FoodMaterialDto input);
    }
}
