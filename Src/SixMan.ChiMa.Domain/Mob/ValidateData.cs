using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Mob
{
    /// <summary>
    /// 验证码数据
    /// </summary>
    public class ValidateData
        : ChiMaEntityBase
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
        /// 验证类型
        /// </summary>
        public ValidateType ValidateType { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime EffectiveTime { get; set; }

    }
}
