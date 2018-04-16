using Abp.Dependency;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    /// <summary>
    /// 爬虫任务
    /// </summary>
    public interface ICrawlerTask
                        :IJob, ITransientDependency
    {
        void ConfigureJob(JobBuilder job);
        void ConfigureTrigger(TriggerBuilder trigger);

        Type TaskType { get; }

        string Name { get; }
    }
}
