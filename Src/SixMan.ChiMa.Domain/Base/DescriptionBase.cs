using Sixman.Chima.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sixman.Chima.Domain.Base
{
    public abstract class DescriptionBase
        : ChiMaEntityBase
        , IDescription
    {
        [Required]
        [StringLength(256)]
        ///描述
        public string Description { get; set; }
    }
}
