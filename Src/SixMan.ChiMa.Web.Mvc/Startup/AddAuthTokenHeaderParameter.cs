using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace SixMan.ChiMa.Web.Resources.Startup
{
    public class AddAuthTokenHeaderParameter
        : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<IParameter>();
            operation.Parameters.Add(
                   new NonBodyParameter()
                   {
                       Name = "Authorization",
                       In = "header",
                       Type = "string",
                       Required = false
                   });

            //if (operation.Parameters == null) operation.Parameters = new List<IParameter>();

            //var attrs = context.ApiDescription.GetCustomAttributes<GlobalAuthorizationFilter>();

            //foreach (var attr in attrs)
            //{ 
            //    // 如果 Attribute 是我们自定义的验证过滤器
            //    if (attr.GetType() == typeof(AddAuthTokenHeaderParameter))
            //    {
            //        operation.Parameters.Add(
            //        new NonBodyParameter()
            //        {
            //            Name = "AuthToken", In = "header", Type = "string", Required = false
            //        });
            //    }
            //}
        }
    }
}
