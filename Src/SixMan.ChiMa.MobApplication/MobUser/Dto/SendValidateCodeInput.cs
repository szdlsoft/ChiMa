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
    /// <summary>
    /// 发送短信验证码信息
    /// </summary>
    [AutoMap(typeof(ValidateData))]
    public class SendValidateCodeInput
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
        /// 验证类型：1位数字，0：注册用户；1：重设密码
        /// </summary>
        //[RegularExpression("^\\d{1}$", ErrorMessage = "1位数字，0：注册用户；1：重设密码")]
        [Display(Name = "验证类型")]

        public ValidateType ValidateType { get; set; }
    }

    
}
