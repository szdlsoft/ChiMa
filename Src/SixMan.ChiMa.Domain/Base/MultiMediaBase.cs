using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Base
{
    public abstract class MultiMediaBase
       : DescriptionBase
       , IMultiMedia
    {

        [StringLength(LengthConstants.MaxUrlLength)]
        public string Photo { get ; set ; }
        [StringLength(LengthConstants.MaxUrlLength)]
        public string Audio { get ; set ; }
        [StringLength(LengthConstants.MaxUrlLength)]
        public string Video { get ; set ; }
    }
}
