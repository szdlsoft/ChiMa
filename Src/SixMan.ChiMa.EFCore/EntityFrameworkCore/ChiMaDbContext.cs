using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SixMan.ChiMa.Domain.Authorization.Roles;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.MultiTenancy;
using Sixman.Chima.Domain.Food;

namespace SixMan.ChiMa.EFCore
{
    public class ChiMaDbContext : AbpZeroDbContext<Tenant, Role, User, ChiMaDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<FoodMaterialCategory> FoodMaterialCategory { get; set; }

        public ChiMaDbContext(DbContextOptions<ChiMaDbContext> options)
            : base(options)
        {
        }
    }
}
