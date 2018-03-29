using Abp.AutoMapper;
using SixMan.ChiMa.Authentication.External;

namespace SixMan.ChiMa.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
