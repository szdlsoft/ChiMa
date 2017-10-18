using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;

namespace SixMan.ChiMa.Application.Authorization.Accounts.Dto
{
    public class IsTenantAvailableInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
