﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SixMan.ChiMa.Domain.Authorization.Roles;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.MultiTenancy;
using Sixman.Chima.Domain.Food;
using Sixman.Chima.Domain.Dish;

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
        public virtual DbSet<Condiment> Condiment { get; set; }

        public ChiMaDbContext(DbContextOptions<ChiMaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
