using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Extensions;
using SixMan.ChiMa.Domain.Extensions;

namespace SixMan.ChiMa.Web.Extensions
{
    public static class ModelMetadataExtensions
    {
        private static IEnumerable<string> IgnoreShowList = new List<string>()
        {
            "Id"
            ,"IsDeleted"
            ,"DeleterUserId"
            ,"DeletionTime"
            ,"LastModificationTime"
            ,"LastModifierUserId"
            ,"CreationTime"
            ,"CreatorUserId"
            ,
        };
        public static bool ShowList(this ModelMetadata meta)
        {
            return meta.PropertyName.IsNotInList(IgnoreShowList)
                   && !meta.PropertyName.EndsWith("Id");
        }

        public static string Title(this ModelMetadata meta)
        {
            return meta.DisplayName ?? meta.PropertyName;
        }

        public static string JsonPropertyName(this ModelMetadata meta)
        {
            return meta.PropertyName.ToCamelCase();
        }
    }
}
