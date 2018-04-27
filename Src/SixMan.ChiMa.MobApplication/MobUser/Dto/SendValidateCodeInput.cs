using Abp.AutoMapper;
using Microsoft.AspNetCore.Identity;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Mob;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application.MobUser
{
    [AutoMap(typeof(ValidateData))]
    public class SendValidateCodeInput
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [StringLength(ChiMaConsts.MobileLength, MinimumLength = ChiMaConsts.MobileLength)]
        public string Mobile { get; set; }
        /// <summary>
        /// 验证类型
        /// </summary>
        public ValidateType ValidateType { get; set; }
    }

    
}
