using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 家庭
    /// </summary>
    public class Family
        : ChiMaEntityBase
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        public Guid UUID { get; set; }
        public ICollection<FamilyMember> Members { get; set; }
        public ICollection<UserInfo> Users { get; set; }
        /// <summary>
        /// 家庭创建人
        /// </summary>
        public UserInfo Creater { get; set; }
    }
}
