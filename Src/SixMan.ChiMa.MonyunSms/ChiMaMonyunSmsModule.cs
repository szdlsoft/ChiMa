using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using SixMan.ChiMa.Domain.Mob;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.MonyunSms
{
    public class ChiMaMonyunSmsModule
        : Abp.Modules.AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaMonyunSmsModule).GetAssembly());

            //IocManager.IocContainer.AddComponent<ISMSSender, MonyunSmsSender>();

            //IocManager.IocContainer.Register(
            //    Component.For<ISMSSender>()
            //    .ImplementedBy<MonyunSmsSender>()
            //    .LifestyleSingleton()
            //    );
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }


    }
}
