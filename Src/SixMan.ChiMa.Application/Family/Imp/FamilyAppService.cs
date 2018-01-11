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
        protected FamilyAppService(IFamilyRepository repository
                                  , IRepository<UserInfo,long> userInfoRepository
                                    ) 
            : base(repository)
        {
            _userInfoRepository = userInfoRepository;
        }

        protected IFamilyRepository familyResponsitory => Repository as IFamilyRepository;

        public Domain.Family.Family GetByUser(long userId)
        {
            //Domain.Family.Family family = familyResponsitory.GetByUser(userId);
            Domain.Family.Family family = Repository.GetAllIncluding(f => f.Users.Any(u => u.Id == userId)).FirstOrDefault();
            if ( family == null)
            {
                family = CreateFamily(userId);
            }
            return family;
        }       

        private Domain.Family.Family CreateFamily(long userId)
        {
            Domain.Family.Family entity = new Domain.Family.Family()
            {
                UUID = Guid.NewGuid(),
                Creater = new UserInfo()
                {
                    UserId = userId
                }
            };

            return Repository.Get( Repository.InsertAndGetId(entity));
        }
    }
}
