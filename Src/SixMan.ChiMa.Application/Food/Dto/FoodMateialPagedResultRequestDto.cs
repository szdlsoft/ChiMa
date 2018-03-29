using System;
using Abp.Application.Services.Dto;

namespace SixMan.ChiMa.Application.Food.Dto
{
    public class FoodMateialPagedResultRequestDto
        : PagedResultRequestDto
    {
        public FoodMateialPagedResultRequestDto()
            : base()
        {
        }

        public long? FoodMaterialCategoryId { get; set; }
        public string Name { get; set; }
    }
}
