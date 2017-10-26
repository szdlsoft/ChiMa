using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 家庭成员
    /// </summary>
    public class FamilyMember
        : ChiMaEntityBase
    {
        public Family Family { get; set; }
        /// <summary>
        /// 人员类别
        /// </summary>
        public PersonEnum PersonKind { get; set; }
        /// <summary>
        /// 性别
        /// 女:false
        /// 男:true
        /// </summary>
        public bool? Sex { get; set; }
        /// <summary>
        /// 年龄段
        /// </summary>
        public Range Age{ get; set; }
        /// <summary>
        /// 人员健康关注
        /// </summary>
        public ICollection<PersonHealthAffect> FoodMaterialHealthAffects { get; set; }
    }


}
