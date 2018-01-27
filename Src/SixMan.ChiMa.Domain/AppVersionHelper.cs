/**************************************************************
 * 版本  说明
 * 1.0.1.01  修复domain event handler 的bug
 * 1.0.1.02  1 和purchase的bug
 *     1.1 分析原因
 *           a: 编译警告的忽略，对死递归应该有Wraning
 *           b: 单元测试的确实， inmenmoru 至少找出逻辑上的bug
 *           c: Filter的经验不足，其实它是全局性的，要当心
 *    2 烹饪步骤的数据
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * **********************************************************/

using System;
using System.IO;
using Abp.Reflection.Extensions;

namespace SixMan.ChiMa.Domain
{
    /// <summary>
    /// Central point for application version.
    /// </summary>
    public class AppVersionHelper
    {
        /// <summary>
        /// Gets current version of the application.
        /// It's also shown in the web page.
        /// </summary>
        public const string Version = "1.0.1";

        /// <summary>
        /// Gets release (last build) date of the application.
        /// It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate
        {
            get { return new FileInfo(typeof(AppVersionHelper).GetAssembly().Location).LastWriteTime; }
        }
    }
}
