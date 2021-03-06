﻿using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Events.Bus;
using SixMan.ChiMa.Domain;
using Abp.Application.Services;
using Abp.Web.Models;

namespace SixMan.ChiMa.Application
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    [Abp.Authorization.AbpAuthorize]
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

       
    }
}
