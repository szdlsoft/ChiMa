using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public abstract class DescriptionBaseDto
        : ChiMaEntityBaseDto
        , IDescription
    {
        public const int MaxDescriptionLength = 256;
        public const int MinDescriptionLength = 2;
        [Required]
        [StringLength(MaxDescriptionLength)]
        [MinLength(MinDescriptionLength)]
        ///描述
        [Display(Name ="名称",Order =0)]
        public string Description { get; set; }
    }
}
