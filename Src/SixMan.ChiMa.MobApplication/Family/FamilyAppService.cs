//using SixMan.ChiMa.Application.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.Domain.Family;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Authorization;
using SixMan.ChiMa.Application.Dish;
using SixMan.ChiMa.Domain;
using Abp.Application.Services;
using SixMan.ChiMa.Domain.Authorization.Users;

namespace SixMan.ChiMa.Application.Family
{
    [AbpAuthorize]
    public class FamilyAppService
        : MobileAppServiceBase<Domain.Family.Family, FamilyDto>
        , IFamilyAppService
    {
        //IRepository<UserInfo, long> _userInfoRepository;
        IRepository<SixMan.ChiMa.Domain.Dish.Dish, long> _dishRepository;
        IRepository<UserFavoriteDish, long> _userFavoriteDishRepository;
        public FamilyAppService(IFamilyRepository repository
                                  , IRepository<SixMan.ChiMa.Domain.Dish.Dish, long> dishRepository
                                  , IRepository<UserFavoriteDish, long> userFavoriteDishRepository
                                    ) 
            : base(repository)
        {
            //_userInfoRepository = userInfoRepository;
            _dishRepository = dishRepository;
            _userFavoriteDishRepository = userFavoriteDishRepository;
        }

        [RemoteService(isEnabled:false)]
        public void HandleEvent(MobUserCreateEvent eventData)
        {
            if( eventData.FamilyId == null
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

            Repository.Insert(entity);

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

        public void UpdateMyFavorites(UpdateFavoriteInput input)
        {
            var dish = _dishRepository.GetAllIncluding(d => d.UserUserFavorites)
                                 .Where(d => d.Id == input.DishId)
                                 .FirstOrDefault();
            if (dish == null)
            {
                throw new Exception($"Id= {input.DishId} 的菜品不存在！");
            }

            UserFavoriteDish fav = dish.UserUserFavorites.SingleOrDefault(f => f.UserInfo.Id == UserInfo.Id);
            if (input.IsFavorites)
            {
                if (fav == null)
                {
                    fav = new UserFavoriteDish()
                    {
                        UserInfo = UserInfo,
                        Dish = dish
                    };

                    _userFavoriteDishRepository.Insert(fav);
                }
            }
            else
            {
                if (fav != null)
                {
                    _userFavoriteDishRepository.Delete(fav.Id);
                }
            }

        }
    }
}
