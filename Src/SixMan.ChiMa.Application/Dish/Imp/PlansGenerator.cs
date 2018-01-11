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

            IList<Domain.Dish.Dish> dishs = _dishRepository.GetAll()
                                            .OrderBy(d => d.Description)
                                            .Take(6)
                                            .ToList();

            //早
            plans.Add(new Plan()
            {
                Dish = dishs[0],
                KindNO = 1,
            });
            plans.Add(new Plan()
            {
                Dish = dishs[1],
                KindNO = 1,
            });

            //中
            plans.Add(new Plan()
            {
                Dish = dishs[2],
                KindNO = 2,
            });
            plans.Add(new Plan()
            {
                Dish = dishs[3],
                KindNO = 2,
            });
            //晚
            plans.Add(new Plan()
            {
                Dish = dishs[4],
                KindNO = 3,
            });
            plans.Add(new Plan()
            {
                Dish = dishs[5],
                KindNO = 3,
            });

            foreach( var p in plans)
            {
                p.Family = family;
                p.PlanDate = planDate;
                p.Kinds = "早，中，晚";
            }

            return plans;
        }
    }
}
