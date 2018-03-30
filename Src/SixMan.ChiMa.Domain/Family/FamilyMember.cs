using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 注意：家庭成员不一定有用户信息！
        /// 用户信息可为空
        /// </summary>
        public UserInfo UserInfo { get; set; }
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

        //家庭昵称
        [MaxLength(LengthConstants.MaxNameLength)]
        public string NickName { get; set; }
        //身高
        public int Height { get; set; }
        //体重
        public int Weight { get; set; }
        //忌口
        [MaxLength(LengthConstants.MaxDescriptionLength)]
        public string AvoidFoods { get; set; }
        //慢性病
        [MaxLength(LengthConstants.MaxDescriptionLength)]
        public string Chronic { get; set; }
        //职业
        public Career Career { get; set; }
        //收入
        public Range Income { get; set; }

        /// <summary>
        /// 人员健康关注
        /// </summary>
        public ICollection<PersonHealthAffect> FoodMaterialHealthAffects { get; set; }
    }


}
