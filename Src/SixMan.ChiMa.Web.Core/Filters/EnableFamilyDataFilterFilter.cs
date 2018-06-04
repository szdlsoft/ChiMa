using Abp.Dependency;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc.Filters;
using SixMan.ChiMa.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Filters
{
    public class EnableFamilyDataFilterFilter : IAsyncActionFilter, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public EnableFamilyDataFilterFilter(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                if (context.Controller is IUseFamilyDataFilter)
                {
                    (context.Controller as IUseFamilyDataFilter).UseFamilyDataFilter();
                }

                await next();
                await uow.CompleteAsync();
            }

            return;
        }
    }
}
