using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.EFCore.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SixMan.ChiMa.Domain.Authorization.Users;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Repositories
{
    public class FamilyRepository
       : ChiMaRepositoryBase<Family, long>
       , IFamilyRepository
    {
        public FamilyRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public Family GetByUser(long userId)
        {
            var p = from f in Context.Family
                    join ui in Context.UserInfo on f.Id equals ui.Family.Id
                    join u in Context.Users on ui.UserId equals u.Id
                    where u.Id == userId
                    select f;
            var family = p.FirstOrDefault();

            return family;
        }
    }
}
