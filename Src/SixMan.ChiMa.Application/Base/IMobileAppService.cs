using Abp.Application.Services;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public interface IMobileAppService
        :IApplicationService, ITransientDependency
    {
    }
}
