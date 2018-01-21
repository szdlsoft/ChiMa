using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Dish;

namespace SixMan.ChiMa.EFCore.EntityFrameworkCore.Seed.FoodAndDish
{
    public class FoodAndDishBuilder
    {
        private readonly ChiMaDbContext _context;

        public FoodAndDishBuilder(ChiMaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //加10个食材
           if( _context.FoodMaterial.Count() < 2)//没有2个才加
            {
                for(int i=0; i<10; i++)
                {
                    _context.FoodMaterial.Add(new FoodMaterial()
                    {
                        Description = $"食材{i+1}",
                    });
                }

                _context.SaveChanges();
            }


            //加10个菜 
            if (_context.Dish.Count() < 1)//没有才加
            {
                FoodMaterial[] fms = _context.FoodMaterial.Take(2).ToArray();

                for (int i = 0; i < 10; i++)
                {
                    _context.Dish.Add(new Dish()
                    {
                        Description = $"菜品{i + 1}",
                        DishBoms = new List<DishBom>()
                        {
                            new DishBom(){ FoodMaterial = fms[0], Matching = 0.2 },
                            new DishBom(){ FoodMaterial = fms[1], Matching = 0.3 },
                        }
                    });
                }

                _context.SaveChanges();
            }

        }
    }
}
