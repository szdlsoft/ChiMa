using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Models
{
    public class MetaViewModel
    {
        public ModelMetadata Meta { get; set; }
        public ModelExplorer ModelExplorer { get; set; }
    }
}
