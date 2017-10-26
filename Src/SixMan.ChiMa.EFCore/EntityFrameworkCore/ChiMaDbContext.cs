using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SixMan.ChiMa.Domain.Authorization.Roles;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.MultiTenancy;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Domain.Common;

namespace SixMan.ChiMa.EFCore
{
    public class ChiMaDbContext : AbpZeroDbContext<Tenant, Role, User, ChiMaDbContext>
    {
        //食材
        public virtual DbSet<FoodMaterialCategory> FoodMaterialCategory { get; set; }
        public virtual DbSet<FoodMaterial> FoodMaterial { get; set; }
        public virtual DbSet<HealthConcernCategory> HealthConcernCategory { get; set; }
        public virtual DbSet<HealthConcern> HealthConcern { get; set; }
        public virtual DbSet<FoodMaterialHealthAffect> FoodMaterialHealthAffect { get; set; }
        //菜品
        public virtual DbSet<DishCategory> DishCategory { get; set; }
        public virtual DbSet<Taste> Taste { get; set; }
        public virtual DbSet<CookMethod> CookMethod { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishBom> DishBom { get; set; }
        public virtual DbSet<Cookery> Cookery { get; set; }
        //家庭
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<FamilyMember> FamilyMember { get; set; }
        public virtual DbSet<PersonHealthAffect> PersonHealthAffect { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        public ChiMaDbContext(DbContextOptions<ChiMaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //一下会建新表
            //modelBuilder.Entity<FoodMaterialCategory>().HasBaseType<CategoryBase>();
            //modelBuilder.Entity<HealthConcernCategory>().HasBaseType<CategoryBase>();

            //modelBuilder.Entity<DishCategory>().HasBaseType<CategoryBase>();
            //modelBuilder.Entity<Taste>().HasBaseType<CategoryBase>();
            //modelBuilder.Entity<CookMethod>().HasBaseType<CategoryBase>();
            //efcore 不支持ComplexType
            //modelBuilder.ComplexType<Range>();
            modelBuilder.Entity<FamilyMember>().OwnsOne<Range>(fm => fm.Age);
            modelBuilder.Entity<FamilyMember>().OwnsOne<Range>(fm => fm.Income);

            //用户和个人信息
            modelBuilder.Entity<UserInfo>()
                .HasOne(ui => ui.User)
                .WithOne(u => u.UserInfo)
                .HasForeignKey<UserInfo>(ui => ui.UserId);
        }
    }
}
