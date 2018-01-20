//using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    public interface IPlanAppService
        //: IMobileAppService<PlanDto,  PlanCreateDto, PlanUpdateDto>
        : IReadAppService<PlanDto>
        , ICreateAppService<PlanDto, PlanCreateDto>
        , IUpdateAppService<PlanDto, PlanUpdateDto>
        , IDeleteAppService
    {
        /// <summary>
        /// 2.1 获取需要的月份的菜谱计划，用于菜谱日历的显示
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        IList<DayPlanFlag> GetByMonth(DateTime month);
        /// <summary>
        /// 2.2 获取指定日期的菜谱，用于用户菜谱的显示
        /// </summary>
        /// <param name="planDate"></param>
        /// <returns></returns>
        IList<PlanDto> GetByDate(DateTime planDate);
        /// <summary>
        /// 今日上桌
        /// </summary>
        /// <returns></returns>
        IList<PlanDto> GetTodayAtTable();

    }
}
