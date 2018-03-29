using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Family
{
    public interface IFamilyRepository
        : IRepository<Domain.Family.Family, long>
    {
        Domain.Family.Family GetByUser(long userId);
    }
}
