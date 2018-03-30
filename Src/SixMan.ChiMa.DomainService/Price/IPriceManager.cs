using Abp.Domain.Services;
using SixMan.ChiMa.Domain.Price;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService.Price
{
    /// <summary>
    /// 价格管理
    /// </summary>
    public interface IPriceManager : IDomainService
    {
        /// <summary>
        /// 获取最新价格时间
        /// </summary>
        /// <param name="area">地区名</param>
        /// <returns></returns>
        DateTime? GetLatest(string area);

        void Save(string areaName, DateTime publishTime, IEnumerable<FMPriceItem> prices);
    }
}
