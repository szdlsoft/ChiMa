﻿//using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Application.Dish;
using Abp.Events.Bus.Handlers;
using SixMan.ChiMa.Domain;

namespace SixMan.ChiMa.Application.Family
{
    public interface IFamilyAppService
    : IMobileAppService
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
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        MobUserInfoDto GetCurrentUserInfo();
        /// <summary>
        /// 修改当前用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        MobUserInfoDto UpdateCurrentUserInfo(UpdateMobUserInfoInput input );
    }
}
