using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 用户关注
    /// </summary>
    public class UserAttention
        : ChiMaEntityBase
    {
        public UserInfo Attention { get; set; }
        public UserInfo Fan { get; set; }
    }
}
