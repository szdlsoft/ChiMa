﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public interface IFoodDetailsAppService
        : IMobileAppService
    {
        IList<MobFoodMaterialDto> GetSeasons();
    }
}
