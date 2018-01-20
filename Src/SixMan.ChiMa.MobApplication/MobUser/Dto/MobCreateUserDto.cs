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
        //: MobileBaseDto 
        //, IShouldNormalize
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(AbpUserBase.MaxNameLength)]
        //public string Name { get; set; }

        //[Required]
        //[StringLength(AbpUserBase.MaxSurnameLength)]
        //public string Surname { get; set; }

        //[Required]
        //[EmailAddress]
        //[StringLength(AbpUserBase.MaxEmailAddressLength)]
        //public string EmailAddress { get; set; }

        //public bool IsActive { get; set; }

        //public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public long? FamilyId { get; set; }

        public void Normalize()
        {
            //if (RoleNames == null)
            //{
            //    RoleNames = new string[0];
            //}
            //RoleNames = new string[] { "Mob" };
        }
    }
}
