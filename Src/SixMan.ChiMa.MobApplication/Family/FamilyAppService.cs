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
using SixMan.ChiMa.Domain.Dish;
using AutoMapper;
using Abp.Domain.Uow;

namespace SixMan.ChiMa.Application.Family
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]

    public class FamilyAppService
        : MobileAppServiceBase<Domain.Family.Family, FamilyDto>
        , IFamilyAppService
    {
        IDishRepository _dishRepository;
        IRepository<UserFavoriteDish, long> _userFavoriteDishRepository;
        IRepository<FamilyMember, long> _familyMemberRepository;
        public FamilyAppService(IFamilyRepository repository
                                  , IDishRepository dishRepository
                                  , IRepository<UserFavoriteDish, long> userFavoriteDishRepository
                                  , IRepository<FamilyMember, long> familyMemberRepository
                                    ) 
            : base(repository)
        {
            _dishRepository = dishRepository;
            _userFavoriteDishRepository = userFavoriteDishRepository;
            _familyMemberRepository = familyMemberRepository;
        }

        [AbpAuthorize]
        public void UpdateMyFavorites(UpdateFavoriteInput input)
        {
            //var dish = _dishRepository.GetAllIncluding(d => d.UserUserFavorites)                                      
            //                     .Where(d => d.Id == input.DishId)
            //                     .FirstOrDefault();
            var dish = _dishRepository.GetAWithUserFavorites(input.DishId);

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

        [AbpAuthorize]
        public MobUserInfoDto GetCurrentUserInfo()
        { 
            return MpaToMobUserInfoDto(UserInfo);
        }

        private MobUserInfoDto MpaToMobUserInfoDto(UserInfo userInfo)
        {
            var dto = Mapper.Map<UserInfo, MobUserInfoDto>(userInfo);
            //dto.HeadPortrait = $"{ChiMaConsts.ImagePath}/{ UserInfo.HeadPortraitImgPath}/{dto.HeadPortrait}" ;
            return dto;
        }

        [AbpAuthorize]
        [UnitOfWork]
        public virtual MobUserInfoDto UpdateCurrentUserInfo(UpdateMobUserInfoInput input)
        {
            try
            {
                UserInfo userInfo = ObjectMapper.Map(input, UserInfo);
                return MpaToMobUserInfoDto( _userInfoRepository.Update(UserInfo));
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex.Message, ex);
                if( ex.InnerException != null)
                {
                    Logger.Fatal(ex.InnerException.Message, ex.InnerException);
                }

                throw new Abp.UI.UserFriendlyException(ex.Message);
            }
        }

        [AbpAuthorize]
        public void UpdateCurrentUserFamily( long newFamilyId )
        {
            if( Family.Id != newFamilyId)
            {
                Family = _familyResponsitory.Get(newFamilyId);

                UserInfo.Family = Family;
                UserInfo.FamilyId = Family.Id;

                _userInfoRepository.Update(UserInfo);
            }
        }

        [AbpAuthorize]
        public FamilyDto Get()
        {
            var family = _familyResponsitory.GetAllIncluding( f => f.Members,
                                                              f => f.UserInfos )
                                             .Where( f => f.Id == Family.Id )
                                             .FirstOrDefault();
            return MapToEntityDto( family );
        }

        [AbpAuthorize]
        public ICollection<FamilyMemberDto> SetMembers(SetMembersInput input)
        {
            List<FamilyMember> oldMembers = _familyMemberRepository.GetAll().ToList();
            foreach( var inputMember in input)
            {
                var oldMember = oldMembers.FirstOrDefault(om => om.Id == inputMember.Id);
                if (oldMember != null)
                {
                    var updateMember = Mapper.Map(inputMember, oldMember);
                    _familyMemberRepository.Update(updateMember);

                    oldMembers.Remove(oldMember);
                }
                else
                {
                    var newMember = Mapper.Map<FamilyMember>( inputMember );
                    newMember.Family = Family;
                    _familyMemberRepository.Insert(newMember);
                }
            }

            foreach( var m in oldMembers)
            {
                _familyMemberRepository.Delete(m);
            }

            CurrentUnitOfWork.SaveChanges();


            return Mapper.Map<List<FamilyMemberDto>>(_familyMemberRepository.GetAll().ToList());
        }
    }
}
