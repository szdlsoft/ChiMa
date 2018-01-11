using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.EFCore.Repositories;
using System;
using System.Linq;
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

        public Family GetByUser(long userId)
        {
            return GetAllIncluding(f => f.Users.Any(u => u.Id == userId) ).FirstOrDefault();
        }
    }
}
