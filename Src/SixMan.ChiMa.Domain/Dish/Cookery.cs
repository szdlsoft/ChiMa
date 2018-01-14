using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    /// <summary>
    /// 烹饪法步骤
    /// </summary>
    public class Cookery
        : MultiMediaContentBase
        , IOrder, IContent
    {
        public Dish Dish { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 时间
        /// </summary>
        public int? Time { get; set; }

        public ICollection<CookeryNote> CookeryNotes { get; set; }
        
    }
}
