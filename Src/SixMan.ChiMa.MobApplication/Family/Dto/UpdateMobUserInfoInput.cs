using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Family
{
    [AutoMapTo(typeof(UserInfo))]
    public class UpdateMobUserInfoInput
    {
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
    }
}
