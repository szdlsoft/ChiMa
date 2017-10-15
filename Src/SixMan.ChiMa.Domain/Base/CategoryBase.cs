using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sixman.Chima.Domain.Base
{
    public abstract class CategoryBase
        : ChiMaEntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
