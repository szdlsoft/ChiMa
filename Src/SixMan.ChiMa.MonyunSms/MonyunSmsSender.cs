using Newtonsoft.Json;
using SixMan.ChiMa.Domain.Mob;
using SixMan.ChiMa.MonyunSms.isms;
using SixMan.ChiMa.MonyunSms.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SixMan.ChiMa.MonyunSms
{
    public class MonyunSMSSender
        : Abp.Domain.Services.DomainService
        ,ISMSSender
    {


        private bool isKeepAlive = true;

        private Account account; // = Account.getInstance();

        //private bool isKeepAlive = true;
        //private string userid = string.Empty;
        //private string pwd = string.Empty;
        //private string ipport = string.Empty;
        private string apikey = string.Empty;
        //private int messageType = 0;
        private int authenticationMode = 0;
        //private bool isMd5 = true;
        ///// <summary>
        ///// 固定字串
        ///// </summary>
        private const string FIX_STRING = "00000000";

        JsonSend _jsonSend;
        public MonyunSMSSender(JsonSend jsonSend)
        {
            _jsonSend = jsonSend;
        }

        /**
           * 对密码进行加密
           * 
           * @description
           * @param userid
           *        账号
           * @param pwd
           *        原始密码
           * @param timestamp
           *        时间戳
           * @return 加密后的密码
           * @author JoNllen <jonllen.zn@qq.com>
           * @datetime 2016-9-1 下午01:40:55
           */
        public string encode(String userid, String pwd, String timestamp)
        {
            // 加密后的字符串 
            return Md5Helper.MD5Encrypt((userid + FIX_STRING + pwd + timestamp), 32).ToLower();
        }
        /// <summary>
        /// 初始发送对象
        /// </summary>
        /// <returns></returns>
        private Message initMessage()
        {
            string imeStamp = DateTime.Now.ToString("MMddHHmmss");
            string password = encode(account.UserId, account.PassWord, imeStamp);
            Message msg = new Message()
            {
                UserId = account.UserId,
                TimeStamp = imeStamp,
                Pwd = password,
                ApiKey = null
            };
            return msg;
        }
      

        /// <summary>
        /// 统一提交
        /// </summary>
        /// <param name="message">请求对象</param>
        /// <param name="sendType">请求类型,1:单发，2：相同内容群发，3：不同类型群发，4：获取上行，5：获取状态报告，6：获取账号余额</param>
        /// <returns></returns>
        private string submit(Message message, int sendtype)
        {
            try
            {               
                //var sms = new JsonSend();
                //String ipport = getIpPortByAccount(account);
                String ipport = account.Ip;
                return _jsonSend.execute(message, sendtype, ipport, authenticationMode, isKeepAlive);
            }
            catch (Exception ex)
            {
                throw new Abp.UI.UserFriendlyException(ex.Message, ex);
            }
        }

        public void Send(SMessage message)
        {
            account = new Account() //暂时写死
            {
                UserId= "E1035V",
                PassWord= "9Gl441",
                Ip = "api01.monyun.cn:7901"
            };


            Message msg = initMessage();
            msg.Mobile = message.Mobile.Trim();
            msg.Content = message.Content.Trim();
            msg.ExNo = "";
            msg.CustId = message.CustId;
            msg.ExData = "";
            msg.SvrType = message.SvrType;
            //提交
            var strResult  = submit(msg, 1);

            Logger.Info(strResult);

            // 根据返回内容判断是否正确?
            //{"result":0,"msgid":5635184289429894454,"custid":"c333333"}
            var response = JsonConvert.DeserializeObject<JsonResult>(strResult);
            if( response == null 
                || response.result != 0)
            {
                throw new Abp.UI.UserFriendlyException($"发送短信码失败:{response.result}");
            }
        }
    }

    public class JsonResult
    {
        public int result { get; set; }
        public string msgid { get; set; }
        public string custid { get; set; }
    }
}
