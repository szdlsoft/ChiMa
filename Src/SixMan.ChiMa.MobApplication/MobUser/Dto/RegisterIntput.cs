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
        //[StringLength(ChiMaConsts.MobileLength, MinimumLength = ChiMaConsts.MobileLength)]
        [RegularExpression("^((1[3,5,8][0-9])|(14[5,7])|(17[0,6,7,8])|(19[7]))\\d{8}$", ErrorMessage = "11位手机号。")]
        [Display(Name = "手机号")]
        public string Mobile { get; set; }
        /// <summary>
        /// 手机短信验证码
        /// 保证是手机本人注册
        /// </summary>
        [Required]
        //[StringLength(ChiMaConsts.ValidateCodeLength, MinimumLength = ChiMaConsts.ValidateCodeLength, ErrorMessage ="4位")]
        [RegularExpression("^\\d{4}$", ErrorMessage = "4位数字")]
        [Display(Name = "短信验证码")]
        public string ValidateCode { get; set; }
        /// <summary>
        /// 密码
        /// 密码规则：
        /// </summary>
        [Required]
        //[StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        [RegularExpression("^\\w{6}$", ErrorMessage = "6位数字或字母或下划线")]
        [Display(Name = "密码")]
        public string Password { get; set; }
        /// <summary>
        /// 家庭id号
        /// </summary>
        [Display(Name = "家庭ID")]
        public long? FamilyId { get; set; }
    }

   
}
