using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.Family;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public class MobUserCreateHandler
        : IEventHandler<MobUserCreateEvent>
          , Abp.Dependency.ISingletonDependency
    {
        protected readonly IFamilyRepository _familyResponsitory;
        protected readonly IRepository<UserInfo, long> _userInfoRepository;

        public MobUserCreateHandler(IFamilyRepository familyResponsitory
                                   , IRepository<UserInfo, long> userInfoRepository)
        {
            _familyResponsitory = familyResponsitory;
            _userInfoRepository = userInfoRepository;
        }

        [RemoteService(isEnabled: false)]
        public void HandleEvent(MobUserCreateEvent eventData)
        {
            if (eventData.FamilyId == null
                || eventData.FamilyId.Value == 0)
            {
                CreateFamily(eventData.User);
            }
            else
            {
                CreateUserInfo(eventData);
            }
        }

        private void CreateFamily(User user)
        {
            Domain.Family.Family family = Domain.Family.Family.Create(user);
            _familyResponsitory.Insert(family);
        }

        private void CreateUserInfo(MobUserCreateEvent eventData)
        {
            var userInfo = UserInfo.Create(eventData.User, eventData.FamilyId, false);
            _userInfoRepository.Insert(userInfo);
        }
    }
}
