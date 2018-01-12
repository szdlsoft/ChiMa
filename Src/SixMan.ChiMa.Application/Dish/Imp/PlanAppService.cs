using SixMan.ChiMa.Application.Base;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Application.Family;

namespace SixMan.ChiMa.Application.Dish
{
    public class PlanAppService
        : AdvancedAsyncCrudAppService<SixMan.ChiMa.Domain.Dish.Plan, PlanDto>
        , IPlanAppService
    {
        protected readonly IPlansGenerator _plansGenerator;
        protected readonly IFamilyAppService _familyService;
        public PlanAppService(IPlanRepository repository
                                , IFamilyAppService familyService
                                , IPlansGenerator plansGenerator) 
            : base(repository)
        {
            _plansGenerator = plansGenerator;
            _familyService = familyService;
        }

        protected IPlanRepository PlanRepository => Repository as IPlanRepository;

        public IList<PlanDto> GetGetPlans(DateTime planDate)
        {
            if ( ! AbpSession.UserId.HasValue)
            {
                throw new Exception("未登录，不能获取菜单计划！");
            }
            SixMan.ChiMa.Domain.Family.Family family = _familyService.GetByUser(AbpSession.UserId.Value);
            //IList<Plan> list = PlanRepository.Get(planDate, family.Id);
            IList<Plan> list = Repository.GetAllIncluding( p => p.Family )
                                         .Where(
                                                p => p.PlanDate == planDate
                                                && p.Family.Id ==  family.Id)
                                         .ToList();

            if ( list.Count() < 1)//没有计划，需加入计划并生成一个新的内容，如已计划请返回原有数据
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
