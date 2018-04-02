using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Price;
using SixMan.ChiMa.Domain.Common;

namespace SixMan.ChiMa.DomainService.Price
{
    public class PriceManager
        : Abp.Domain.Services.DomainService
        , IPriceManager
    {
        public IRepository<AreaFMPrice,long> AreaFMPriceRepository { get; set; }
        public IRepository<Area> AreaRepository { get; set; }
        public DateTime? GetLatest(string areaName)
        {
            return AreaFMPriceRepository.GetAllIncluding( a => a.Area )
                                        .Where( a => a.Area.Name == areaName)
                                        .OrderByDescending( a => a.PublishTime)
                                        .Select( a => a.PublishTime)
                                        .Take(1).FirstOrDefault();
        }

        public void Save(string areaName, DateTime publishTime, IEnumerable<FMPriceItem> prices)
        {
            var priceList = prices.ToList();
            if( priceList.Count < 1) // 没有价格信息
            {
                return;
            }

            Area area = AreaRepository.FirstOrDefault(a => a.Name == areaName);
            AreaFMPrice afp = new AreaFMPrice()
            {
                Area = area,
                PublishTime = publishTime,
                FMPriceItems = priceList
            };

            AreaFMPriceRepository.Insert(afp);
        }
    }
}
