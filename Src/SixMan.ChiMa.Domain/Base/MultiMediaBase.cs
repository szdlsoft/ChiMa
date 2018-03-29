﻿using SixMan.ChiMa.Domain.Interface;
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
        public const int MaxUrlLength = 512;

        [StringLength(MaxUrlLength)]
        public string Photo { get ; set ; }
        [StringLength(MaxUrlLength)]
        public string Audio { get ; set ; }
        [StringLength(MaxUrlLength)]
        public string Video { get ; set ; }
    }
}
