using SixMan.ChiMa.Domain.Authorization.Users;
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
        public ICollection<UserInfo> UserInfos { get; set; }

        public static Family Create(User user)
        {
            Domain.Family.Family family = new Domain.Family.Family()
            {
                UUID = Guid.NewGuid(),
            };

            UserInfo CreateUserInfo = UserInfo.Create(user);

            family.UserInfos = new List<UserInfo>() { CreateUserInfo }; //这个办法，是可以的创建关联子记录 

            return family;

        }

        /// <summary>
        /// 家庭创建人
        /// </summary>        
        //public UserInfo CreateUserInfo { get; set; }
    }
}
