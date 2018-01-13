using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 用户评论菜谱
    /// </summary>
    public class UserCommentDish
        : ChiMaEntityBase
    {
        public UserInfo UserInfo { get; set; }
        public SixMan.ChiMa.Domain.Dish.Dish Dish { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(DescriptionBase.MaxDescriptionLength)]
        public string Content { get; set; }
        /// <summary>
        /// 点赞
        /// </summary>
        public int? Rate { get; set; }
    }
}
