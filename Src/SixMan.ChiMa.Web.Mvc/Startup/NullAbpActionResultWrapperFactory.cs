using Abp;
using Abp.AspNetCore.Mvc.Results.Wrapping;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Startup
{
    public class NullAbpActionResultWrapperFactory
        : IAbpActionResultWrapperFactory
    {
        public IAbpActionResultWrapper CreateFor(ResultExecutingContext actionResult)
        {
            Check.NotNull(actionResult, nameof(actionResult));

            //if (actionResult.Result is ObjectResult)
            //{
            //    return new AbpObjectActionResultWrapper();
            //}

            //if (actionResult.Result is JsonResult)
            //{
            //    return new AbpJsonActionResultWrapper();
            //}

            //if (actionResult.Result is EmptyResult)
            //{
            //    return new AbpEmptyActionResultWrapper();
            //}

            return new NullAbpActionResultWrapper();
        }
    }
}
