using System.Collections.Generic;
using Abp.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SixMan.ChiMa.Web.Views.Shared.Components.ListPage
{
    public class ListPageViewModel
    { 
        public ModelMetadata Meta { get; set; }
    }
}