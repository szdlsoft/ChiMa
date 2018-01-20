using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Events.Bus;
using SixMan.ChiMa.Domain;
using Abp.Application.Services;

namespace SixMan.ChiMa.Application
{
    public class FoodMaterialInventoryAppService
        : MobileAppServiceBase<FoodMaterialInventory, FoodMaterialInventoryDto>
        , IFoodMaterialInventoryAppService
    {
        //public IEventBus EventBus { get; set; }
        public FoodMaterialInventoryAppService(IRepository<FoodMaterialInventory, long> repository) : base(repository)
        {
            //EventBus = NullEventBus.Instance;
        }

        public IList<FoodMaterialInventoryDto> GetList()
        {
            return Repository.GetAllIncluding(fi => fi.FoodMaterial
                                             ,fi => fi.Family)
                             .Where(fi => fi.Family.Id == Family.Id)
                             .Select( MapToEntityDto)
                             .ToList();
        }

        [RemoteService(isEnabled:false)]
        public void HandleEvent(FoodMaterialInventoryChangeEvent eventData)
        {
            var fmi = Repository.GetAllIncluding(fi => fi.FoodMaterial
                                                 , fi => fi.Family)
                             .Where(fi => fi.Family.Id == Family.Id
                                       && fi.FoodMaterial.Id == eventData.FoodMaterial.Id)
                             .FirstOrDefault();
            if( fmi == null)
            {
                Repository.Insert(new FoodMaterialInventory()
                {
                    FoodMaterial = eventData.FoodMaterial,
                    Inventory = eventData.Volume,
                    Family = Family
                });
            }
            else
            {
                fmi.Inventory += eventData.Volume;
                Repository.Update(fmi);
            }
        }
    }
}
