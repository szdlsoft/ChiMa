using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public class FoodMaterialInventoryChangeHandler
        : IEventHandler<FoodMaterialInventoryChangeEvent>
          , Abp.Dependency.ISingletonDependency
    {
        IRepository<FoodMaterialInventory, long> _repository;
        public FoodMaterialInventoryChangeHandler(IRepository<FoodMaterialInventory, long> repository)
        {
            _repository = repository;
        }

        [RemoteService(isEnabled: false)]
        public void HandleEvent(FoodMaterialInventoryChangeEvent eventData)
        {
            var fmi = _repository.GetAllIncluding(fi => fi.FoodMaterial
                                                 , fi => fi.Family)
                             .Where(fi => fi.Family.Id == eventData.Family.Id
                                       && fi.FoodMaterial.Id == eventData.FoodMaterial.Id)
                             .FirstOrDefault();
            if (fmi == null)
            {
                _repository.Insert(new FoodMaterialInventory()
                {
                    FoodMaterial = eventData.FoodMaterial,
                    Inventory = eventData.Volume,
                    Family = eventData.Family
                });
            }
            else
            {
                fmi.Inventory += eventData.Volume;
                _repository.Update(fmi);
            }
        }
    }
}
