using SixMan.ChiMa.Application.Base;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Domain.Family;

namespace SixMan.ChiMa.Application.Dish
{
    public class PlanAppService
        : AdvancedAsyncCrudAppService<SixMan.ChiMa.Domain.Dish.Plan, PlanDto>
        , IPlanAppService
    {
        protected readonly IPlansGenerator _plansGenerator;
        protected readonly IFamilyRepository _familyRepository;
        protected PlanAppService(IPlanRepository repository
                                , IFamilyRepository familyRepository
                                , IPlansGenerator plansGenerator) 
            : base(repository)
        {
            _plansGenerator = plansGenerator;
            _familyRepository = familyRepository;
        }

        protected IPlanRepository PlanRepository => Repository as IPlanRepository;

        public IList<PlanDto> Get(DateTime planDate)
        {
            SixMan.ChiMa.Domain.Family.Family family = _familyRepository.GetByUser(AbpSession.UserId);
            IList<Plan> list = PlanRepository.Get(planDate, family.Id);
                       // .Include()
                       // .Where(   p => p.PlanDate == planDate
                       //             && p.Family.Id == AbpSession.User.UserInfo.Family.Id)
                       // .ToList();
                       //;
            if( list.Count() < 1)//没有计划，需加入计划并生成一个新的内容，如已计划请返回原有数据
            {
                IList<Plan> newPlans = _plansGenerator.BuildPlans(planDate, family);
                list = SaveAndGet(newPlans);
            }            

            return list.Select(MapToEntityDto).ToList();
        }       

        private IList<Plan> SaveAndGet(IList<Plan> newPlans)
        {
            foreach( var plan in newPlans)
            {
                plan.Id = PlanRepository.InsertAndGetId(plan);
            }

            return newPlans;
        }
    }
}
