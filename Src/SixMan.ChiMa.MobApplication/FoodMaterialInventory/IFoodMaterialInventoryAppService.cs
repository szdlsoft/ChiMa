﻿using Abp.Events.Bus.Handlers;
using SixMan.ChiMa.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public interface IFoodMaterialInventoryAppService
        : 
          IMobileAppService
    {
        IList<FoodMaterialInventoryDto> GetList();
    }
}
