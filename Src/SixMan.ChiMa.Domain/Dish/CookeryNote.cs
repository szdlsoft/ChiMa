using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    /// <summary>
    /// 烹饪笔记
    /// </summary>
    public class CookeryNote
        : MultiMediaBase
    {
        public Cookery Cookery { get; set; }
        public UserInfo UerInfo { get; set; }
    }
}
