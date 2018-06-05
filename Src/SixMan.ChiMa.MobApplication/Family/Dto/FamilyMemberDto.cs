using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Common;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Family
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Family.FamilyMember))]
    public class FamilyMemberDto
        :MobileBaseDto
    {
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
        //public Range Age { get; set; }

        //家庭昵称
        public string NickName { get; set; }
        //身高
        public int Height { get; set; }
        //体重
        public int Weight { get; set; }
        //忌口
        public string AvoidFoods { get; set; }
        //慢性病
        public string Chronic { get; set; }
    }
}
