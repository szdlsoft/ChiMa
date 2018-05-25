using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Family;
using Abp.Domain.Repositories;
using System.Linq;

namespace SixMan.ChiMa.Application.Dish
{
    public class PlansGenerator
        : IPlansGenerator
    {
        IRepository<SixMan.ChiMa.Domain.Dish.Dish, long> _dishRepository;
        public PlansGenerator(IRepository<SixMan.ChiMa.Domain.Dish.Dish, long> dishRepository)
        {
            _dishRepository = dishRepository;
        }
        /// <summary>
        /// 暂时 生成早中晚个两道菜 
        /// </summary>
        /// <param name="planDate"></param>
        /// <param name="family"></param>
        /// <returns></returns>
        public IList<Plan> BuildPlans(DateTime planDate, Domain.Family.Family family)
        {
            List<Plan> plans = new List<Plan>();

            //IList<Domain.Dish.Dish> allDishs = _dishRepository.GetAll()
            //                                .OrderBy(d => d.Id)
            //                                .Take(10)
            //                                .ToList();

            //IList<Domain.Dish.Dish> dishs = RadomGet(allDishs);
            //早餐 1主食 2热菜 1汤羹
            plans.AddRange(GetDP(MealType.早餐, "主食", "热菜", "汤羹"));

            //plans.Add(new Plan()
            //{
            //    Dish = dishs[0],
            //    MealType = MealType.早餐,
            //    MealNo = 1
            //});
            //plans.Add(new Plan()
            //{
            //    Dish = dishs[1],
            //    MealType = MealType.早餐,
            //    MealNo = 2
            //});

            //午餐 1主食 1热菜 1凉菜 1汤羹
            plans.AddRange(GetDP(MealType.午餐, "主食", "热菜",  "凉菜", "汤羹"));
            //plans.Add(new Plan()
            //{
            //    Dish = dishs[2],
            //    MealType = MealType.中餐,
            //    MealNo = 1
            //});
            //plans.Add(new Plan()
            //{
            //    Dish = dishs[3],
            //    MealType = MealType.中餐,
            //    MealNo = 2
            //});
            //晚餐 1主食 2热菜 1汤羹
            plans.AddRange(GetDP(MealType.晚餐, "主食", "热菜",  "汤羹"));
            //plans.Add(new Plan()
            //{
            //    Dish = dishs[4],
            //    MealType = MealType.晚餐,
            //    MealNo = 1
            //});
            //plans.Add(new Plan()
            //{
            //    Dish = dishs[5],
            //    MealType = MealType.晚餐,
            //    MealNo = 2
            //});

            foreach( var p in plans)
            {
                p.Family = family;
                p.PlanDate = planDate;
                //p.Kinds = "早，中，晚";
            }

            return plans;
        }

        private IEnumerable<Plan> GetDP(MealType mealType, params string[] tags )
        {
            int order = 1;
            string meal = mealType.ToString();
            foreach( var tag in tags)
            {
                var count = _dishRepository.Count(d => d.DishCategory.Contains(tag)
                                        && d.DishCategory.Contains(meal));
                var dish =
                _dishRepository.GetAll()
                               .Where(d => d.DishCategory.Contains(tag)
                                        && d.DishCategory.Contains(meal))
                               .Skip(RandomNum(count))
                               .Take(1)
                               .FirstOrDefault();
                if( dish != null)
                {
                    yield return new Plan()
                    {
                        Dish = dish,
                        MealType = mealType,
                        MealNo = order++
                    };
                }
            }
        }
        private int RandomNum(int count)
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.Next(0, count - 1); ;
        }

        /// <summary>
        /// 随机取6个菜,只要不同就行
        /// 总的菜必须大于6，否则会死循环！
        /// </summary>
        /// <param name="allDishs"></param>
        /// <returns></returns>
        private IList<Domain.Dish.Dish> RadomGet(IList<Domain.Dish.Dish> allDishs, int radomNum = 6)
        {
            List<Domain.Dish.Dish> randomDishs = new List<Domain.Dish.Dish>();

            int count = allDishs.Count();
            var random = new Random(DateTime.Now.Millisecond);
            for (int i=0; i< radomNum; i++)
            {
                int randomIndex = 0;
                do
                {
                    randomIndex = random.Next(0, count - 1);
                }
                while (randomDishs.Exists(rd => rd == allDishs[randomIndex]));

                randomDishs.Add(allDishs[randomIndex]);
            }

            return randomDishs;
        }
        /// <summary>
        /// 根据参别，随机生成一个菜
        /// </summary>
        /// <param plan="plan"></param>
        /// <returns></returns>
        public long GetRandomChange(Plan plan)
        {
            string meal = plan.MealType.ToString();
            var count = _dishRepository.Count(d => d.DishCategory.Contains(meal));

            var dish =
               _dishRepository.GetAll()
                              .Where(d => d.DishCategory.Contains(meal))
                              .Skip(RandomNum(count))
                              .Take(1)
                              .FirstOrDefault();
            if (dish != null)
            {
                return dish.Id;
            }

            return plan.DishId;   //找不到，还用原来的
        }
    }
}
