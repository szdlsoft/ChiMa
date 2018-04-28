using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.MonyunSms {
    /**
 * @功能概要： 账号信息类
 * @项目名称： CSharpSmsSDK
 * @初创作者： JoNllen <jonllen.zn@qq.com>
 * @公司名称： ShenZhen Montnets Technology CO.,LTD.
 * @创建时间： 2016-10-11 上午11:53:42
 *        <p>
 *        修改记录1：
 *        </p>
 * 
 *        <pre>
 *      修改日期：
 *      修改人：
 *      修改内容：
 * </pre>
 */
    public class MultiMt {
        /// <summary>
        ///  获取或设置手机号
        /// </summary>
        public string mobile = string.Empty;

        /// <summary>
        /// 获取或设置 短信内容
        /// </summary>
        public string content = string.Empty;

        /// <summary>
        /// 获取或设置 业务类型
        /// </summary>
        public string svrtype = string.Empty;

        /// <summary>
        /// 获取或设置 扩展号
        /// </summary>
        public string exno = string.Empty;

        /// <summary>
        ///  获取或设置用户自定义的消息编号
        /// </summary>
        public string custid = string.Empty;

        /// <summary>
        /// 获取或设置 自定义扩展数据
        /// </summary>
        public string exdata = string.Empty;
 
    }
}
