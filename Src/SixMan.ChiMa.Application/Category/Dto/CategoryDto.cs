using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Category.Dto
{
    public class CategoryDto
        : EntityDto<long>
        , IEntity<long>
        , ICategory
    {

        public CategoryDto(long categoryId, string category)
        {
            this.Id = categoryId;
            Category = category;
        }

        [Required]
        [StringLength(CategoryBase.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(CategoryBase.MaxCodeLength)]
        public string Code { get; set; }

        public string Category { get; set; }

        public bool IsTransient()
        {
            return false;
        }
    }
}
