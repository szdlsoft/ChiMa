/**************************************************************
 * 版本  说明
 * 1.0.1  修复domain event handler 的bug
 * 
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
