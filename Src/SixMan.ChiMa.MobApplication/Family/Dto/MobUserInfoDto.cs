using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Common;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Family
{
    [AutoMapFrom(typeof(UserInfo))]
    public class MobUserInfoDto
         : EntityDto<long>
    {
        //手机号
        public string Mobile { get; set; }
        //头像
        public string HeadPortrait { get; set; }
        //昵称
        public string NickName { get; set; }
        //性别
        public bool? Sex { get; set; }
        //生日
        public DateTime? BirthDay { get; set; }       
        //个性签名
        public string Signature { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        //积分
        public int Credits { get; set; }

        public long FamilyId { get; set; }

        public bool IsFamilyCreater { get; set; }
    }
}
