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
    /// 重设密码信息
    /// </summary>
    public class ResetPasswordIntput
    {
        /// <summary>
        /// 手机号：11位数字
        /// </summary>
        [Required]
        //[StringLength(ChiMaConsts.MobileLength, MinimumLength = ChiMaConsts.MobileLength)]
        [RegularExpression("^((1[3,5,8][0-9])|(14[5,7])|(17[0,6,7,8])|(19[7]))\\d{8}$", ErrorMessage = "11位手机号。")]
        [Display(Name = "手机号")]
        public string Mobile { get; set; }
        /// <summary>
        /// 手机短信验证码：4位数字
        ///// </summary>
        [Required]
        //[StringLength(ChiMaConsts.ValidateCodeLength, MinimumLength = ChiMaConsts.ValidateCodeLength)]
        [RegularExpression("^\\d{4}$", ErrorMessage = "4位数字")]
        [Display(Name = "短信验证码")]

        public string ValidateCode { get; set; }
        
        //public string OldPassword { get; set; }
        /// <summary>
        /// 新密码：6位数字或字母或下划线
        /// </summary>
        [Required]
        //[StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        [RegularExpression("^\\w{6}$", ErrorMessage = "6位数字或字母或下划线")]
        [Display(Name = "密码")]

        public string NewPassword { get; set; }
    }

   
}
