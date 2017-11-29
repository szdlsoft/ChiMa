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
        public const string IMAGE = "图片";
        public const string AUDIO = "音频";
        public const string VIDEO = "视频";

        [Display(Name = IMAGE, Order =4)]
        [StringLength(MaxUrlLength)]
        public string Photo { get ; set ; }
        [Display(Name = AUDIO, Order = 51)]
        [StringLength(MaxUrlLength)]
        public string Audio { get ; set ; }
        [Display(Name = VIDEO, Order = 52)]
        [StringLength(MaxUrlLength)]
        public string Video { get ; set ; }
    }
}
