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

            IList<Domain.Dish.Dish> allDishs = _dishRepository.GetAll()
                                            .OrderBy(d => d.Id)
                                            .Take(10)
                                            .ToList();

            IList<Domain.Dish.Dish> dishs = RadomGet(allDishs);
            //早
            plans.Add(new Plan()
            {
                Dish = dishs[0],
                MealType = MealType.早餐,
                MealNo = 1
            });
            plans.Add(new Plan()
            {
                Dish = dishs[1],
                MealType = MealType.早餐,
                MealNo = 2
            });

            //中
            plans.Add(new Plan()
            {
                Dish = dishs[2],
                MealType = MealType.中餐,
                MealNo = 1
            });
            plans.Add(new Plan()
            {
                Dish = dishs[3],
                MealType = MealType.中餐,
                MealNo = 2
            });
            //晚
            plans.Add(new Plan()
            {
                Dish = dishs[4],
                MealType = MealType.晚餐,
                MealNo = 1
            });
            plans.Add(new Plan()
            {
                Dish = dishs[5],
                MealType = MealType.晚餐,
                MealNo = 2
            });

            foreach( var p in plans)
            {
                p.Family = family;
                p.PlanDate = planDate;
                //p.Kinds = "早，中，晚";
            }

            return plans;
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
    }
}
