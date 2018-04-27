using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using SixMan.ChiMa.Domain.Authorization.Users;

namespace SixMan.ChiMa.Application
{
    [AutoMapTo(typeof(User))]
    public class MobCreateUserDto 
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }      

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public long? FamilyId { get; set; }

        
    }
}
