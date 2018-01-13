using SixMan.ChiMa.Application.Base;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Application.Family;
using Abp.Authorization;
using Abp.Application.Services;

namespace SixMan.ChiMa.Application.Dish
{
    [AbpAuthorize]
    public class PlanAppService
        : MobileAppService<Plan,PlanDto>
        , IPlanAppService
    {
        protected readonly IPlanRepository _repository;
        protected readonly IPlansGenerator _plansGenerator;
        protected readonly IFamilyAppService _familyService;
        public PlanAppService(IPlanRepository repository
                                , IFamilyAppService familyService
                                , IPlansGenerator plansGenerator) 
            : base(repository)
        {
            _repository = repository;
            _plansGenerator = plansGenerator;
            _familyService = familyService;
        }

        //protected IPlanRepository _repository => Repository as IPlanRepository;
        protected override PlanDto MapToEntityDto(Plan entity)
        {
            var dto = base.MapToEntityDto(entity);

            dto.Dish.UserCommentCount = entity.Dish.UserComments.Count();
            dto.Dish.UserUserFavoriteCount = entity.Dish.UserUserFavorites.Count();
            dto.Dish.IsMyFavorite = entity.Dish.UserUserFavorites.Any(fav => fav.UserInfoId == UserInfo.Id);

            return dto;
        }

        public IList<PlanDto> GetByDate(DateTime planDate)
        {            
            SixMan.ChiMa.Domain.Family.Family family = _familyService.GetOrCreate();
            IList<Plan> list = _repository.Get(planDate, family.Id );

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
                plan.Id = _repository.InsertAndGetId(plan);
            }

            return newPlans;
        }

        public IList<DayPlanFlag> GetByMonth(DateTime month)
        {
            List<DayPlanFlag> monthFlags = new List<DayPlanFlag>();

            var lastMonthDay = month.AddMonths(1).Subtract(TimeSpan.FromDays(1));

            var monthPlanDayList = _repository.GetAll()
                                 .Where(
                                         p => p.PlanDate >= month
                                           && p.PlanDate <= lastMonthDay)
                                 .Select(p => p.PlanDate)
                                 .Distinct()
                                 .ToList();

            for ( DateTime day = month; day <= lastMonthDay; day = day.AddDays(1))
            {
                monthFlags.Add(new DayPlanFlag()
                {
                    Day = day,
                    HasPlan = monthPlanDayList.Any(mpd => mpd == day)
                });
            }

            return monthFlags;
        }

    }
}
