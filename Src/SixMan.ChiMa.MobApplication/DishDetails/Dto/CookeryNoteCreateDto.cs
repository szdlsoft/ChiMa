using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    public class CookeryNoteCreateDto
    {
        [Required]
        public long CookeyId { get; set; }
        [Required]
        [StringLength(MobileDescriptionBaseDto.MaxDescriptionLength)]
        [MinLength(MobileDescriptionBaseDto.MinDescriptionLength)]
        public string Description { get; set; }
    }
}
