using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Linq;

namespace SixMan.ChiMa.Application
{
    public class PurchaseAppService
        : MobileAppServiceBase<Purchase, PurchaseDto, PurchaseCreateDto,PurchaseUpdateDto>
        , IPurchaseAppService
    {
        public PurchaseAppService(IRepository<Purchase, long> repository) : base(repository)
        {
        }

        protected override Purchase MapToEntity(PurchaseCreateDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            if( entity.Family == null)
            {
                entity.Family = Family;
            }
            return entity;
        }

        public PurchaseDto Create(PurchaseCreateDto input)
        {
            return CreateImp(input);
        }
        public PurchaseDto Update(PurchaseUpdateDto input)
        {
            return UpdateImp(input);
        }

        public IList<PurchaseDto> GetByDateRange(DateRangeDto dateRange)
        {
            var entities = Repository.GetAllIncluding( p => p.FoodMaterial
                                                      ,p => p.FoodMaterial.FoodMaterialCategory)
                                     .Where( p => p.PurchaseTime >= dateRange.From
                                               && p.PurchaseTime <= dateRange.To)
                                     .ToList();
            return entities.Select(MapToEntityDto).ToList();
        }

       
    }
}
