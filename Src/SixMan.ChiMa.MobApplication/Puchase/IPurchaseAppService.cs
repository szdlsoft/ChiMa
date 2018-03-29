using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public interface IPurchaseAppService
        : IMobileAppService
        , ICreateAppService<PurchaseDto, PurchaseCreateDto>
        , IUpdateAppService<PurchaseDto, PurchaseUpdateDto>
    {
        IList<PurchaseDto> GetByDateRange(DateRange dateRange);
    }
}
