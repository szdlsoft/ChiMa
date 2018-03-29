using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    [AutoMap(typeof(Purchase))]
    public class PurchaseUpdateDto
       : MobileBaseDto
        , IEntityDto<long>
    {
        public bool HasPurchased { get; set; }
    }
}
