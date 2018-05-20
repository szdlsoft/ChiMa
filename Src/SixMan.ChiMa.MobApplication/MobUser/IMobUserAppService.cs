using Microsoft.AspNetCore.Identity;
using SixMan.ChiMa.Application.MobUser;
using SixMan.ChiMa.Domain.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    /// <summary>
    /// 手机端用户服务
    /// </summary>
    public interface IMobUserAppService
        : IMobileAppService
    {
        /// <summary>
        /// 新手机用户注册
        /// </summary>
        /// <param name="userRegisterIntput"></param>
        /// <returns></returns>
        void Register(RegisterIntput userRegisterIntput);
        /// <summary>
        /// 老用户重置密码
        /// </summary>
        /// <param name="userResetPasswordIntput"></param>
        /// <returns></returns>
        void ResetPassword(ResetPasswordIntput userResetPasswordIntput);
        /// <summary>
        /// 发送手机验证码短信
        /// </summary>
        /// <param name="sendValidateCodeInput"></param>
        /// <returns></returns>
        void SendValidateCode(SendValidateCodeInput sendValidateCodeInput);
        /// <summary>
        /// 取消（删除）注册用户
        /// </summary>
        /// <param name="unUserRegisterIntput"></param>
        void UnRegister(UnRegisterIntput unUserRegisterIntput);
    }
}
