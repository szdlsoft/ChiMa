using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.TagHelpers
{
    public interface IModelExplorerProvider
    {
        ModelExplorer ModelExplorer { get; set; }
    }
}
