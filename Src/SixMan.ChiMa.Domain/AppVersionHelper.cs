﻿/**************************************************************
 * 
 * 
 * 
 * 
 * 
 * 版本  说明
 * 1.0.1.01  修复domain event handler 的bug
 * 1.0.1.02  1 和purchase的bug
 *     1.1 分析原因
 *           a: 编译警告的忽略，对死递归应该有Wraning
 *           b: 单元测试的确实， inmenmoru 至少找出逻辑上的bug
 *           c: Filter的经验不足，其实它是全局性的，要当心
 *    2 烹饪步骤的数据
 * 1.0.2.03  PlanDto的MealType改为文字返回，并根据mealtype和orderno排序
 *           Swagger ui 显示版本号
 * 1.0.3.04  Fix UpdateMyFavorites 两次调用会出错
 * 1.0.3.05  Add 食材列表
 * 1.0.4.06  Add 食材列表 工具栏、查询
 * 1.0.4.07  Add 食材  新增、编辑 如果选择了Catetegory还有bug要处理
 * 1.0.4.08 2018-02-06  食材图像上传，路径和条件要处理
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
        public const string Version = "1.0.4.08";

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
