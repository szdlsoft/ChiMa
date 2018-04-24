using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public interface IFoodMaterialAndDishImport
        : IDomainService
    {
        void Execute();
    }
}
