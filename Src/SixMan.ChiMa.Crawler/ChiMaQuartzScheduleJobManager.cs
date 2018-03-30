using Abp.BackgroundJobs;
using Abp.Quartz;
using Abp.Quartz.Configuration;
using Abp.Threading.BackgroundWorkers;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler
{
    public class ChiMaQuartzScheduleJobManager
        : BackgroundWorkerBase
        , IChiMaQuartzScheduleJobManager
    {
        private readonly IBackgroundJobConfiguration _backgroundJobConfiguration;
        private readonly IAbpQuartzConfiguration _quartzConfiguration;


        public ChiMaQuartzScheduleJobManager(IAbpQuartzConfiguration quartzConfiguration, IBackgroundJobConfiguration backgroundJobConfiguration)
        {
            _quartzConfiguration = quartzConfiguration;
            _backgroundJobConfiguration = backgroundJobConfiguration;

        }

        public  Task ScheduleAsync(ICrawlerTask task)
        {
            var jobToBuild = JobBuilder.Create(task.TaskType);
            task.ConfigureJob(jobToBuild);
            var job = jobToBuild.Build();

            var triggerToBuild = TriggerBuilder.Create();
            task.ConfigureTrigger(triggerToBuild);
            var trigger = triggerToBuild.Build();

            _quartzConfiguration.Scheduler.ScheduleJob(job, trigger);

            return Task.FromResult(0);
        }

        public override void Start()
        {
            base.Start();

            if (_backgroundJobConfiguration.IsJobExecutionEnabled)
            {
                _quartzConfiguration.Scheduler.Start();
            }
        }

        public override void WaitToStop()
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                try
                {
                    _quartzConfiguration.Scheduler.Shutdown(true);
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.ToString(), ex);
                }
            }

            base.WaitToStop();
        }
    }
}
