//using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Application.Dish;

namespace SixMan.ChiMa.Application.Family
{
    public interface IFamilyAppService
    :  IMobileAppService<FamilyDto, FamilyDto, FamilyDto>
    {
        /// <summary>
        /// 获得或创建家庭
        /// </summary>
        /// <returns></returns>
        //Domain.Family.Family GetOrCreate();
        /// <summary>
        /// 我的喜好变更
        /// </summary>
        /// <returns></returns>
        void UpdateMyFavorites(UpdateFavoriteInput input);
    }
}
