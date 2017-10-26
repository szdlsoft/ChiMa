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
    {
        //手机号
        [MaxLength(CategoryBase.MaxNameLength)]
        public string Mobile { get; set; }
        //头像
        [StringLength(MultiMediaBase.MaxUrlLength)]
        public string HeadPortrait { get; set; }
        //昵称
        [MaxLength(CategoryBase.MaxNameLength)]
        public string NickName { get; set; }
        //性别
        public bool? Sex { get; set; }
        //生日
        public DateTime? BirthDay { get; set; }
        //职业
        public Career Career { get; set; }
        //家乡
        public City City { get; set; }
        //个性签名
        [MaxLength(DescriptionBase.MaxDescriptionLength)]
        public string Signature { get; set; }
        //积分
        public int Credits { get; set; }

        public long UserId { get; set; }
        //用户
        [ForeignKey("UserId")]
        public User User { get; set; }
        //家庭
        public Family Family { get; set; }
        //关注
        [InverseProperty("Attention")]

        public ICollection<UserAttention> Attentions { get; set; }
        //粉丝
        [InverseProperty("Fan")]
        public ICollection<UserAttention> Fans { get; set; }
    }
}
