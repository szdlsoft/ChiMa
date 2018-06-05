using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Family
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Family.Family))]
    public class FamilyDto
        : MobileBaseDto
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        public Guid UUID { get; set; }        
        ///// <summary>
        ///// 家庭创建人
        ///// </summary>
        //public MobUserInfoDto Creater { get; set; }

        public ICollection<FamilyMemberDto> Members { get; set; }
        public ICollection<MobUserInfoDto> UserInfos { get; set; }
    }
}
