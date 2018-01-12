using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Family;
using Abp.Domain.Repositories;
using System.Linq;

namespace SixMan.ChiMa.Application.Family
{
    public class FamilyAppService
        : AdvancedAsyncCrudAppService<SixMan.ChiMa.Domain.Family.Family, FamilyDto>
        , IFamilyAppService
    {
        IRepository<UserInfo, long> _userInfoRepository;
        public FamilyAppService(IFamilyRepository repository
                                  , IRepository<UserInfo,long> userInfoRepository
                                    ) 
            : base(repository)
        {
            _userInfoRepository = userInfoRepository;
        }

        protected IFamilyRepository familyResponsitory => Repository as IFamilyRepository;

        public Domain.Family.Family GetByUser(long userId)
        {
            Domain.Family.Family family = familyResponsitory.GetByUser(userId);
            //Domain.Family.Family family = Repository.GetAllIncluding(f => f.UserInfos)

            //                                       .Where(f => f.UserInfos.Any(ui => ui.Id == userId))
            //                                       .FirstOrDefault();
            //Domain.Family.Family family = Repository.Single(f => f.Users.Any(u => u.Id == userId));
            if ( family == null)
            {
                family = CreateFamily(userId);
            }
            return family;
        }       

        private Domain.Family.Family CreateFamily(long userId)
        {
            var CreateUserInfo = new UserInfo()
            {
                UserId = userId,
                IsFamilyCreater = true
            };

            Domain.Family.Family entity = new Domain.Family.Family()
            {
                UUID = Guid.NewGuid(),
                //CreateUserInfo = new UserInfo()
                //{
                //    UserId = userId
                //}
            };

            entity.UserInfos = new List<UserInfo>() { CreateUserInfo };

            return Repository.Get( Repository.InsertAndGetId(entity));
        }
    }
}
