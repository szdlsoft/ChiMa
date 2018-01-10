using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Repositories
{
    public class FamilyRepository
       : ChiMaRepositoryBase<Family, long>
       , IFamilyRepository
    {
        protected FamilyRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public Family GetByUser(long? userId)
        {
            throw new NotImplementedException();
        }
    }
}
