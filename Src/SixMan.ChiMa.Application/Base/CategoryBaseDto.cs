using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public abstract class CategoryBaseDto
        : ChiMaEntityBaseDto
        , ICategory
    {
        public const int MinNameLength = 50;
        public const int MaxNameLength = 50;
        public const int MaxCodeLength = 50;

        [Required]
        [StringLength( MaxNameLength)]
        public string Name { get; set; }
        [StringLength(MaxCodeLength)]
        public string Code { get; set; }
        
    }
}
