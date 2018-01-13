using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 用户浏览菜谱
    /// </summary>
    public class UserBrowseDish
        : ChiMaEntityBase
    {
        public UserInfo UserInfo { get; set; }
        public SixMan.ChiMa.Domain.Dish.Dish Dish { get; set; }
        /// <summary>
        /// 浏览时间
        /// </summary>
        public DateTime BrowseTime { get; set; }
    }
}
