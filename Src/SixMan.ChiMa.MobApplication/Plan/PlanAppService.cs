//using SixMan.ChiMa.Application.Base;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Application.Family;
using Abp.Authorization;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Web.Models;

namespace SixMan.ChiMa.Application.Dish
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = true)]
    [AbpAuthorize]
    public class PlanAppService
        : MobileAppServiceBase<Plan, PlanDto, PlanCreateDto, PlanUpdateDto>
        , IPlanAppService
    {
        protected readonly IPlanRepository _repository;
        protected readonly IPlansGenerator _plansGenerator;
        //protected readonly IFamilyAppService _familyService;
        public PlanAppService(IPlanRepository repository
                                , IPlansGenerator plansGenerator) 
            : base(repository)
        {
            _repository = repository;
            _plansGenerator = plansGenerator;
            //_familyService = familyService;
        }

        protected override Plan GetEntityById(long id)
        {
            return Repository.GetAllIncluding( p => p.Dish
                                               , p => p.Dish.UserComments
                                               , p => p.Dish.UserUserFavorites)
                             .Where( p => p.Id == id)
                             .FirstOrDefault();
        }

        public  PlanDto Update(PlanUpdateDto input)
        {
            return Update(input);
       }

        //protected IPlanRepository _repository => Repository as IPlanRepository;
        protected override PlanDto MapToEntityDto(Plan entity)
        {
            if( entity.Dish == null
                || entity.Dish.UserComments == null) //确保关联数据获取！
            {
                entity = GetEntityById(entity.Id);
            }

            var dto = base.MapToEntityDto(entity);

            dto.Dish.UserCommentCount = entity.Dish.UserComments.Count();
            dto.Dish.UserUserFavoriteCount = entity.Dish.UserUserFavorites.Count();
            dto.Dish.IsMyFavorite = entity.Dish.UserUserFavorites.Any(fav => fav.UserInfoId == UserInfo.Id);

            return dto;
        }

        protected override Plan MapToEntity(PlanCreateDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            entity.FamilyId = Family.Id;

            return entity; 
        }

        public IList<PlanDto> GetByDate(DateTime planDate)
        {            
            //SixMan.ChiMa.Domain.Family.Family family = _familyService.GetOrCreate();
            IList<Plan> list = _repository.Get(planDate, Family.Id );

            if ( list.Count() < 1)//没有计划，需加入计划并生成一个新的内容，如已计划请返回原有数据
            {
                IList<Plan> newPlans = _plansGenerator.BuildPlans(planDate, Family);
                SaveList(newPlans);
                list = _repository.Get(planDate, Family.Id);
            }            

            return list.Select(MapToEntityDto).ToList();
        }   

        private void SaveList(IList<Plan> newPlans)
        {
            foreach( var plan in newPlans)
            {
                plan.Id = _repository.InsertAndGetId(plan);
            }
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

        public virtual PlanDto Create(PlanCreateDto input)
        {          

            return CreateImp(input);
        }

        public virtual void Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            Repository.Delete(input.Id);
        }

        public IList<PlanDto> GetTodayAtTable()
        {
            return Repository.GetAll()
                             .Take(3)
                             .Select(MapToEntityDto)
                             .ToList();
        }

    }
}
