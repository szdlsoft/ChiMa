/**************************************************************
 *  版本说明：
 *  大版本号.中版本号.小版本号.revison
 *   大版本号：需求有重大的变化，整体架构有变动
 *   中版本号：数据库结构有变化，架构没有变动
 *   小版本号：小改动，数据库结构没有变化，架构没有变动
 *   revison ： svn 号
 *  change说明
 *    Fix 修改Bug
 *    Add 增加Feature
 *    Upd 修改Feature
 *    Opt 优化Feature
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
 * 1.0.4.09 2018-02-08  食材搞定
 * 
 * 1.1.1   2018-03-30  Add Area、 AreaFMPrice、FMPriceItem
 *                     Add crawertask 和 manager
 * 1.1.2   2018-04-1   Fix 异步执行的[UnitOfWork]、解析日期的问题
 *                     还剩下，机械td的问题TBD
 * 1.1.3   2018-04-2   szfm price crawler 异常处理  
 * 1.1.4   2018-04-11  重构Crawler、美食天下食材分类导入
 * 1.2.1   2018-04-12  Add美食天下食材(含分类、图片、营养成分）导入Task
 *                     Add 营养成分
 *                     Add 导入Manager
 *                     Upd 取消 FoodAndDishBuilder， 改为爬数据
 * 1.2.2  2018-04-13   Add NeedDownloadFoodMaterialImage
 *                     Add 爬到的食材数据按分类，持久化到文件中，便于部署；重构importManager、CrawlerConfig
 * 1.2.3  2018-04-16   Add 爬菜谱总体设计,爬菜谱类别  
 * 1.2.4  2018-04-18   Add 爬菜谱类别 
 * 1.2.5  2018-04-20   Add 爬菜谱类别完成 爬菜谱框架
 * 1.2.6  2018-04-20   Add 爬菜谱列表完成
 * 1.2.7  2018-04-22   Opt 小重构，文件仓库存储,一次性任务直接执行，配置统一到 web.mvc 下！
 *                     Add 爬菜品明细
 * 1.2.8  2018-04-23   Add 爬菜品img 
 * 1.3.1  2018-04-24   Add 爬数据导入数据库
 *                     Upd Dish 结构，加入DataId Tags等
 * 1.3.2  2018-04-25   Fix plan family filter 的bug   
 * 1.3.3  2018-04-25   Add 爬img任务独立，crawler 配置也使用web相同配置，
 * 1.3.4  2018-04-26   Fix linux img crawler 文件路径BUG
 *                     Add dnc Start 配置统一从WEB项目获取，并且自适应开发、生成环境，便于一键发布 
 *                     Add 生成计划算法，考虑早、中、晚餐的来选择菜谱
 *                     Fix JwtBearer 失效改为3天
 *                     Fix Dish CookTime 字符串 转数字! TBD 让前端改吧
 * 1.3.5   2018-04-26  Fix 烹饪步骤没有文字说明bug, 导入的bug咱不改  
 * 1.3.6   2018-04-27  Add 短信验证接口
 * 1.4.1   2018-04-28  Add 短信接口实现、发送短信码、注册、重设密码、、
 * 1.4.2   2018-05-01  Fix 注册用户时异常处理、
 *                     Add 密码规则、Swagger文档
 * 1.4.3   2018-05-14  Add 建立系统用户角色，在注册和发送短信码时，验证该角色权限
 * 1.4.4   2018-05-15  Add 支持https 实际上代码一样，部署nginx配置不同而已！
 * 1.4.5   2018-05-17  Add 苏州食材价格 保存到食材表中
 *                     Fix 食材管理页面混乱
 * 1.4.6   2018-05-18  Opt 食材crud重构，以便在菜品中重用 
 *                     Add 完成菜品、视频分类的crud   
 *                     Fix Production 环境 jquery 没下载！
 * 1.4.7   2018-05-18  Fix eayui css js 没加载
 *                     Fix Production 环境 SZFMPriceCrawler 异常
 * 1.4.8   2018-05-20  Add 删除用户功能   
 * 1.4.9   2018-05-21  Opt simplcrud 组件化
 * 1.4.10  2018-05-22  Opt AbpEasyuiSimpleCrud 组件化
 * 1.4.11  2018-05-23  Add AbpEasyuiSimpleCrud 用后台initCreate *                     
 * 1.4.12  2018-05-24  Upd 重置密码，不需要正则验证
 * 1.4.13  2018-05-24  Add 加入万能验证码供测试
 * 1.4.14  2018-05-25  Opt 公用库UICommon nuget
 * 1.4.15  2018-05-25  Fix 烹饪步骤乱序,后端已用order字段排序，前端好像还是显示乱序
 *                     Upd Plan/Update 后台重新随机生成一个菜，替换原来的菜
 * 1.4.16  2018-06-01  Add 用户头像上传，并且可以用swagger来测试
 * 1.5.1  2018-06-04   Upd FamillyDataFilter
 *                     Add 获取用户信息、修改用户信息  
 *                     Upd UserInfo
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
        public const string Version = "1.5.1";

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
