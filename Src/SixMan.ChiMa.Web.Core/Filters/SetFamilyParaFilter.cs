using Abp.Dependency;
using Microsoft.AspNetCore.Mvc.Filters;
using SixMan.ChiMa.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Filters
{
    public class SetFamilyParaFilter : IAsyncActionFilter, ITransientDependency
    {
        public SetFamilyParaFilter()
        {

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if( context.Controller is ISetFamilyPara)
            {
                (context.Controller as ISetFamilyPara).SetFilterPara();
            }

            await next();
            return;
        }
    }
}
