using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application
{
    public abstract class MultiMediaBaseDto
       : DescriptionBaseDto
       , IMultiMedia
    {
        public const int MaxUrlLength = 512;

        [Display(Name = "图片",Order =50)]
        [StringLength(MaxUrlLength)]
        public string Photo { get ; set ; }
        [Display(Name = "音频", Order = 51)]
        [StringLength(MaxUrlLength)]
        public string Audio { get ; set ; }
        [Display(Name = "视频", Order = 52)]
        [StringLength(MaxUrlLength)]
        public string Video { get ; set ; }
    }
}
