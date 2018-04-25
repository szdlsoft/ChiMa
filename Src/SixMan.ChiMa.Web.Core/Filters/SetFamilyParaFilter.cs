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
    public class SetFamilyParaFilter : IAsyncActionFilter, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SetFamilyParaFilter(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                if (context.Controller is ISetFamilyPara)
                {
                    (context.Controller as ISetFamilyPara).SetFilterPara();
                }

                await next();
                await uow.CompleteAsync();
            }

            return;
        }
    }
}
