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
        public static bool IsShow(this ModelMetadata meta)
        {
            return meta.PropertyName.IsNotInList(IgnoreShowList)
                   && !meta.PropertyName.EndsWith("Id");
        }

        public static bool IsEdit(this ModelMetadata meta)
        {
            return meta.PropertyName.IsNotInList(IgnoreShowList);
        }

        public static string Title(this ModelMetadata meta)
        {
            return meta.DisplayName ?? meta.PropertyName;
        }

        public static string JsonPropertyName(this ModelMetadata meta)
        {
            return meta.PropertyName.ToCamelCase();
        }

        public static string Width(this ModelMetadata meta)
        {
            if(string.Compare( meta.PropertyName, "Description", true) == 0)
            {
                return "30%";
            }

            return "50px";
        }

        public static IEnumerable<ModelMetadata> ShowProperties(this ModelMetadata meta)
        {
            return meta.Properties.Where(p => p.IsShow());
        }

        public static IEnumerable<ModelMetadata> EditProperties(this ModelMetadata meta)
        {
            return meta.Properties.Where(p => p.IsEdit());
        }
    }
}
