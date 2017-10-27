using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 用户收藏菜谱 
    /// </summary>
    public class UserFavoriteDish
        : ChiMaEntityBase
    {
        public UserInfo User { get; set; }
        public SixMan.ChiMa.Domain.Dish.Dish Dish { get; set; }

    }
}
