using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SixMan.ChiMa.Domain.Base
{
    public abstract class CategoryBase
        : ChiMaEntityBase
        , ICategory
    {

        [Required]
        [StringLength(LengthConstants.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(LengthConstants.MaxCodeLength)]
        public string Code { get; set; }

        public CategoryBase()
        {
            this.Code = (DateTime.Now.Millisecond % 10000).ToString("D4");
            this.Name = "新类别" + Code;
        }

    }
}
