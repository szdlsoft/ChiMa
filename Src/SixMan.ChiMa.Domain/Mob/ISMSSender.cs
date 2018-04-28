using SixMan.ChiMa.Domain.Mob;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Mob
{
    /// <summary>
    /// 短信发送者
    /// </summary>
    public interface ISMSSender
        : Abp.Dependency.ITransientDependency
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="message"></param>
        /// <returns>
        ///   成功
        ///   错误 抛 UIFriendException 错误码
        /// </returns>
        void Send(SMessage message);
    }
}
