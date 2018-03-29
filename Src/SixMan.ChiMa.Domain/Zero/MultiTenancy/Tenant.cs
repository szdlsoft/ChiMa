using Abp.MultiTenancy;
using SixMan.ChiMa.Domain.Authorization.Users;

namespace SixMan.ChiMa.Domain.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
