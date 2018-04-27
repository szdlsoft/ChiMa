using Abp.Auditing;
using Abp.Authorization.Users;
using SixMan.ChiMa.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application.MobUser
{
    /// <summary>
    /// 新手机用户注册信息
    /// </summary>
    public class RegisterIntput
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [StringLength(ChiMaConsts.MobileLength, MinimumLength = ChiMaConsts.MobileLength)]
        public string Mobile { get; set; }
        /// <summary>
        /// 手机短信验证码
        /// 保证是手机本人注册
        /// </summary>
        [Required]
        [StringLength(ChiMaConsts.ValidateCodeLength, MinimumLength = ChiMaConsts.ValidateCodeLength)]
        public string ValidateCode { get; set; }
        /// <summary>
        /// 密码
        /// 密码规则：
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }
        /// <summary>
        /// 家庭id号
        /// </summary>
        public long? FamilyId { get; set; }
    }

   
}
