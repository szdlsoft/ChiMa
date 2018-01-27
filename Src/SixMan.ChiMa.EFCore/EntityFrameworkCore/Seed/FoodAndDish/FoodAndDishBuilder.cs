using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Dish;
using Abp;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Seed.FoodAndDish
{
    public class FoodAndDishBuilder
    {
        private readonly ChiMaDbContext _context;

        private const int foodMaterialCategoryNumber = 10;
        private const int foodMaterialNumber = 20;
        private const int dishlNumber = 10;

        public FoodAndDishBuilder(ChiMaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //10个类别
            //加20个食材
            if (_context.FoodMaterialCategory.Count() < 2)//没有2个才加
            {
                for (int i = 0; i < foodMaterialCategoryNumber; i++)
                {
                    _context.FoodMaterialCategory.Add(new FoodMaterialCategory()
                    {
                        Name = $"测试食材类别{i + 1}",
                        Code = (i + 1).ToString(),
                        IndexNo = i + 1
                    });
                }

                _context.SaveChanges();
            }



            //加20个食材
            if ( _context.FoodMaterial.Count() < 2)//没有2个才加
            {
                FoodMaterialCategory[] fms = _context.FoodMaterialCategory.Take(foodMaterialCategoryNumber).ToArray();
                for (int i=0; i< foodMaterialNumber; i++)
                {
                    string name = $"测试食材{i + 1}";
                    _context.FoodMaterial.Add(new FoodMaterial()
                    {
                        Description = name,
                        FoodMaterialCategory = fms[i % foodMaterialCategoryNumber],
                        Photo = $"images/FoodMaterial/{name}.jpg"
                    });
                }

                _context.SaveChanges();
            }


            //加30个菜 
            if (_context.Dish.Count() < 1)//没有才加
            {
                FoodMaterial[] fms = _context.FoodMaterial.Take(foodMaterialNumber).ToArray();

                for (int i = 0; i < dishlNumber; i++)
                {
                    string name = $"测试菜品{i + 1}";
                    _context.Dish.Add(new Dish()
                    {
                        Description = name,
                        DishBoms = new List<DishBom>()
                        {
                            new DishBom(){ FoodMaterial = fms[i % foodMaterialNumber], Matching = GetRandomDouble() },
                            new DishBom(){ FoodMaterial = fms[(i+1)% foodMaterialNumber], Matching = GetRandomDouble() },
                        },
                        Photo = $"images/Dish/{name}.jpg",
                        HPhoto =$"images/Dish/{name}_h.jpg",
                        BPhoto=$"images/Dish/{name}_b.jpg",

                    });
                }

                _context.SaveChanges();
            }

        }

        private double GetRandomDouble()
        {
            return ((double)RandomHelper.GetRandom(0,99)) / 100.0 ;
        }
    }
}
