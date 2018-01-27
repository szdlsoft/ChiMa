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
using Abp.Web.Models;

namespace SixMan.ChiMa.Application.Family
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]

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

       

        [AbpAuthorize]
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
