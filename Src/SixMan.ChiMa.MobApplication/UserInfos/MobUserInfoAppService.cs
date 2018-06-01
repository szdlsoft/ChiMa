using System;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Family;

namespace SixMan.ChiMa.Application.UserInfos
{
    [AbpAuthorize]
    public class MobUserInfoAppService
        : MobileAppServiceBase<Domain.Family.UserInfo, MobUserInfoDto>
    {
        public MobUserInfoAppService(IRepository<UserInfo, long> repository) : base(repository)
        {
        }

        protected override MobUserInfoDto MapToEntityDto(UserInfo entity)
        {
            var dto = base.MapToEntityDto(entity);

            return dto;
        }
    }
}
