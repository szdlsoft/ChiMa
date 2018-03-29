using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Cookery))]
    public class CookeryDto
        : MobileMultiMediaBaseDto
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public int? Time { get; set; }

        public ICollection<CookeryNoteDto> CookeryNotes { get; set; }

    }
}
