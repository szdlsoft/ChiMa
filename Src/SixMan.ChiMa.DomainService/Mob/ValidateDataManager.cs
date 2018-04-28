using Abp.Domain.Repositories;
using Abp.Domain.Services;
using SixMan.ChiMa.Domain.Mob;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService.Mob
{
    /// <summary>
    /// 验证码domainservice
    /// 如出错抛 UIFriendException
    /// </summary>
    public class ValidateDataManager
        : Abp.Domain.Services.DomainService
    {

        IRepository<ValidateData, long> _validateDataRepository;
        public ValidateDataManager(IRepository<ValidateData, long> validateDataRepository)
        {
            _validateDataRepository = validateDataRepository;
        }

        /// <summary>
        /// 生成短信码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="validateType">验证类型</param>
        /// <returns></returns>
        public SMessage Build(string mobile, ValidateType validateType)
        {
            var now = DateTime.Now.AddMinutes(-1);  // 一分钟内, 无需重新生成, 仍然用原来的
            var data = _validateDataRepository.FirstOrDefault(d => d.Mobile == mobile
                                                                && d.ValidateType == validateType
                                                                && d.CreationTime >= now);
            if( data == null)
            {
                data = CreateValidateData(mobile, validateType);
            }

            data.SendNum += 1; // 生成一次,相当于发送一次了
            _validateDataRepository.Update(data);

            SMessage message = new SMessage()
            {
                Mobile = mobile,
                Content = GenerateContent(data.ValidateCode),
                CustId = validateType.ToString(),
            };

            CurrentUnitOfWork.SaveChanges();

            return message;
        }

        private ValidateData CreateValidateData(string mobile, ValidateType validateType)
        {
            var code = Abp.RandomHelper.GetRandom(0, 9999).ToString("0000");

            var id = _validateDataRepository.InsertAndGetId(new ValidateData()
            {
                Mobile = mobile,
                ValidateType = validateType,
                ValidateCode = code,
                EffectiveTime = DateTime.Now.AddMinutes(ChiMaConfig.SMSTimeOfExistence + 1)
            });

            return _validateDataRepository.Get(id);
        }
        /// <summary>
        /// 根据短信模板,来生成短信
        /// </summary>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        private string GenerateContent(string validateCode)
        {
            return string.Format( ChiMaConfig.SMSTemplate, validateCode, ChiMaConfig.SMSTimeOfExistence);
        }

        /// <summary>
        /// 核对短信码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="validateType">验证类型</param>
        /// <param name="validateCode">短信码</param>
        public void CheckValidateCode(string mobile, ValidateType validateType, string validateCode)
        {
            DateTime now = DateTime.Now;
            if( _validateDataRepository.Count(d => d.Mobile == mobile
                                                && d.ValidateType == validateType
                                                && d.ValidateCode == validateCode
                                                && d.EffectiveTime >= now ) 
                                       < 1 )
            {
                throw new Abp.UI.UserFriendlyException($"短信码:{validateCode} 无效!");
            }
        }
    }
}
