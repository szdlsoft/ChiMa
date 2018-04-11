using Abp.Dependency;
using Abp.Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler
{
    public interface IChiMaQuartzScheduleJobManager
        : ISingletonDependency
    {
        Task ScheduleAsync(ICrawlerTask  task) ;
    }
}
