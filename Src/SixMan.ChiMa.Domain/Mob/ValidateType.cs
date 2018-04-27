using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Mob
{
    /// <summary>
    /// 验证类型
    /// </summary>
    public enum ValidateType
    {
        /// <summary>
        /// 新用户注册
        /// </summary>
        Register = 0,
        /// <summary>
        /// 老用户重置密码
        /// </summary>
        ResetPassword = 1,
    }
}
