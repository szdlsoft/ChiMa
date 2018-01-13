using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Family;
using Abp.Dependency;

namespace SixMan.ChiMa.Application
{
    public class MobileAppService<TEntity, TEntityDto>
        : CrudAppService<TEntity, TEntityDto, long>
        where TEntity : class, IEntity<long>
        where TEntityDto : IEntityDto<long>
    {
        protected MobileAppService(IRepository<TEntity, long> repository) : base(repository)
        {
            
        }

        UserInfo _userInfo = null;
        protected UserInfo UserInfo
        {
            get
            {
                if( _userInfo == null)
                {
                    _userInfo = GetOrCreate();
                }

                return _userInfo;
            }
        }

        private UserInfo GetOrCreate()
        {
            if (!AbpSession.UserId.HasValue)
            {
                throw new Exception("未登录，不能创建或获取UserInfo！");
            }
            long userId = AbpSession.UserId.Value;

            var userInfoRepository = IocManager.Instance.IocContainer.Resolve<IRepository<UserInfo, long>>();

            var userInfo = userInfoRepository.Single(ui => ui.User.Id == userId);
            if(userInfo == null)
            {
                userInfo = new UserInfo()
                {
                    UserId = userId,
                };

                userInfo = userInfoRepository.Get(userInfoRepository.InsertAndGetId(userInfo));
            }

            return userInfo;
        }
    }
}
