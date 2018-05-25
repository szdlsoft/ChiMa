using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Extensions;
using SixMan.ChiMa.Domain.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SixMan.UICommon.Extensions;

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
            ,"ExtensionData"
        };
        public static bool IsShow(this ModelMetadata mm)
        {
            return mm.PropertyName.IsNotInList(IgnoreShowList)
                   && !mm.PropertyName.EndsWith("Id");
        }

        public static bool IsEdit(this ModelMetadata mm)
        {
            return mm.PropertyName.IsNotInList(IgnoreShowList)
                  && mm.DataTypeName != "ReadOnly";
        }

        public static string Title(this ModelMetadata mm)
        {
            return mm.DisplayName ?? mm.PropertyName;
        }

        public static string JsonPropertyName(this ModelMetadata mm)
        {
            return mm.PropertyName.ToJsonName();
        }

        public static string Width(this ModelMetadata mm)
        {
            if(string.Compare( mm.PropertyName, "Description", true) == 0)
            {
                return "30%";
            }

            return "50px";
        }

        public static IEnumerable<ModelMetadata> ShowProperties(this ModelMetadata mm)
        {
            return mm.Properties.Where(p => p.IsShow());
        }

        public static IEnumerable<ModelMetadata> EditProperties(this ModelMetadata mm)
        {
            return mm.Properties.Where(p => p.IsEdit());
        }

        public static IEnumerable<ModelExplorer> EditProperties(this ModelExplorer me)
        {
            return me.Properties.Where(p => p.Metadata.IsEdit());
        }
    }
}
