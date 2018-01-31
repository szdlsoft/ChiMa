using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.EFCore.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Repositories
{
    public class DishRepository
        : ChiMaRepositoryBase<Dish, long>
        , IDishRepository
    {
        public DishRepository(IDbContextProvider<ChiMaDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public Dish GetAWithUserFavorites(long id)
        {
            return Context.Dish
                          .Include(d => d.UserUserFavorites)                          
                          .ThenInclude( uf => uf.UserInfo)
                          .Where(d => d.Id == id)
                          .SingleOrDefault();
        }

        public Dish GetWithDetails(long id)
        {
            //var q = from d in Context.Dish
            //        join db in Context.DishBom.DefaultIfEmpty() on d.Id equals db.Dish.Id
            //        select new { d, db } into ddb
            //        join f in Context.FoodMaterial.DefaultIfEmpty() on ddb.db.FoodMaterial.Id equals f.Id
            //        select new { ddb, f } into ddb_f
            //        //join dc in Context.Cookery.DefaultIfEmpty() on d.Id equals dc.Dish.Id
            //        //join dcn in Context.CookeryNote.DefaultIfEmpty() on dc.Id equals dcn.Cookery.Id
            //        //into dcdcn
            //        where ddb_f.ddb.d.Id == id
            //        select ddb_f;

            //var q = GetAll()
            //        .Include("DisBoms")
            //        .Include("FoodMaterial")
            //        .Include("Cookery")
            //        .Include("CookeryNote")
            //        .Where(d => d.Id == id);

            var dish = Get(id);

            dish.DishBoms = Context.DishBom
                                .Include(db => db.Dish)
                                .Include(db => db.FoodMaterial)
                                .Where(db => db.Dish.Id == id)
                                .ToList();

            dish.Cookerys = Context.Cookery
                               .Include(c => c.Dish)
                               .Include(c => c.CookeryNotes)
                               .Where(c => c.Dish.Id == id)
                               .ToList();

            return dish;
        }
    }
}
