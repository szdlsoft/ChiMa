using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Base
{
    public abstract class DescriptionBase
        : ChiMaEntityBase
        , IDescription
    {
        [Required]
        [StringLength(LengthConstants.MaxDescriptionLength)]
        ///描述
        public string Description { get; set; }
    }
}
