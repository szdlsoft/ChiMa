﻿using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Family
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class UserInfo
        : ChiMaEntityBase
        , IHaveFamilyId
    {
        //手机号
        [MaxLength(LengthConstants.MaxNameLength)]
        public string Mobile { get; set; }
        //昵称
        [MaxLength(LengthConstants.MaxNameLength)]
        public string NickName { get; set; }
        //性别
        public bool? Sex { get; set; }
        //生日
        public DateTime? BirthDay { get; set; }
        //职业
        public Career Career { get; set; }
        //家乡
        public Area Area { get; set; }
        //个性签名
        [MaxLength(LengthConstants.MaxDescriptionLength)]
        public string Signature { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(LengthConstants.MaxDescriptionLength)]
        public string Address { get; set; }

        //积分
        public int Credits { get; set; }

        public long UserId { get; set; }
        //用户
        [ForeignKey("UserId")]
        public User User { get; set; }
        //家庭
        public long FamilyId { get; set; }
        [ForeignKey("FamilyId")]
        public Family Family { get; set; }
        /// <summary>
        /// 家庭的创建人
        /// </summary>
        public bool IsFamilyCreater { get; set; }
        //关注
        [InverseProperty("Attention")]

        public ICollection<UserAttention> Attentions { get; set; }
        //粉丝
        [InverseProperty("Fan")]
        public ICollection<UserAttention> Fans { get; set; }
        /// <summary>
        /// 浏览过的菜谱
        /// </summary>
        public ICollection<UserBrowseDish> BrowseDishs { get; set; }
        /// <summary>
        /// 收藏的菜谱
        /// </summary>
        public ICollection<UserFavoriteDish> FavoriteDishs { get; set; }
        /// <summary>
        /// 自制的菜谱
        /// </summary>
        public ICollection<SixMan.ChiMa.Domain.Dish.Dish> HomeMadeDishs { get; set; }


        //头像
        [NotMapped]
        public string HeadPortraitFileName => $"{Id}.jpg";

        [NotMapped]
        public string HeadPortrait => $"{ChiMaConsts.ImagePath}/{ChiMaConsts.HeadPortraitImgPath}/{HeadPortraitFileName}";

        public static UserInfo Create( User user )
        {
            return Create( user, null, true) ;
        }

        public static UserInfo Create(User user, long? familyId, bool isFamilyCreater)
        {
            var userInfo = new UserInfo()
            {
                UserId = user.Id,
                Mobile = user.UserName,
                IsFamilyCreater = isFamilyCreater,
            };

            if( ! isFamilyCreater && familyId.HasValue)
            {
                userInfo.FamilyId = familyId.Value;
            }

            return userInfo;
        }
    }
}
