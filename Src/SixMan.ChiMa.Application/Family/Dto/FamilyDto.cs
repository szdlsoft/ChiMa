using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Family
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Family.Family))]
    public class FamilyDto
        : ChiMaEntityBaseDto
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        public Guid UUID { get; set; }        
        /// <summary>
        /// 家庭创建人
        /// </summary>
        public UserInfo Creater { get; set; }
    }
}
