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
            Domain.Family.Family entity = new Domain.Family.Family()
            {
                UUID = Guid.NewGuid(),
            };
            //entity = Repository.Get( Repository.InsertAndGetId(entity));

            var CreateUserInfo = new UserInfo()
            {
                UserId = user.Id,
                IsFamilyCreater = true,
            };

            entity.UserInfos = new List<UserInfo>() { CreateUserInfo }; //这个办法，是可以的创建关联子记录 

            _familyResponsitory.Insert(entity);

            //var id =  _userInfoRepository.InsertOrUpdateAndGetId(UserInfo);

        }

        private void CreateUserInfo(MobUserCreateEvent eventData)
        {
            var CreateUserInfo = new UserInfo()
            {
                UserId = eventData.User.Id,
                FamilyId = eventData.FamilyId.Value,
                IsFamilyCreater = true
            };

            _userInfoRepository.Insert(CreateUserInfo);
        }
    }
}
