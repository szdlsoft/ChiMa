using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Family;
using Abp.Dependency;
using Abp;
using Abp.UI;
using SixMan.ChiMa.Domain;
using Abp.Domain.Uow;

namespace SixMan.ChiMa.Application
{
    public class MobileAppServiceBase<TEntity, TEntityDto, TCreateInput, TUpdateInput>
        : CrudAppServiceBase<TEntity, TEntityDto, long, PagedAndSortedResultRequestDto, TCreateInput, TUpdateInput>
        //, IMobileAppService<TEntityDto, TCreateInput, TUpdateInput>
        //, IReadAppService<TEntityDto>
        ,IMobileAppService
        , IUseFamilyDataFilter

        where TEntity : class, IEntity<long>
        where TEntityDto : IEntityDto<long>
        where TUpdateInput : IEntityDto<long>
    {
        protected readonly IFamilyRepository _familyResponsitory;
        protected readonly IRepository<UserInfo, long> _userInfoRepository;
        public MobileAppServiceBase(IRepository<TEntity, long> repository) : base(repository)
        {
            _userInfoRepository = IocManager.Instance.IocContainer.Resolve<IRepository<UserInfo, long>>();
            _familyResponsitory = IocManager.Instance.IocContainer.Resolve<IFamilyRepository>();

            //SetFilterPara();
            //var cuw = IocManager.Instance.IocContainer.Resolve<IUnitOfWorkManager>().Current;
            //cuw.SetFilterParameter(ChimaDataFilter.FamillyDataFilter, ChimaDataFilter.FamillyPara, Family);
        }

        [RemoteService(isEnabled:false)]
        [UnitOfWork]
        public void UseFamilyDataFilter()
        {
            CurrentUnitOfWork.SetFilterParameter(ChimaDataFilter.FamillyDataFilter, ChimaDataFilter.FamillyPara, Family);
            EnableFamilyDataFilter();
        }

        protected void EnableFamilyDataFilter()
        {
            CurrentUnitOfWork.EnableFilter(ChimaDataFilter.FamillyDataFilter);

        }

        protected void DisableFamilyDataFilter()
        {
            CurrentUnitOfWork.DisableFilter(ChimaDataFilter.FamillyDataFilter);
        }


        UserInfo _userInfo = null;
        protected UserInfo UserInfo
        {
            get
            {
                if( _userInfo == null)
                {
                    _userInfo = GetOrCreateUserInfo();
                }

                return _userInfo;
            }
        }

        private UserInfo GetOrCreateUserInfo()
        {
            if (!AbpSession.UserId.HasValue)
            {
                throw new UserFriendlyException("未登录，不能创建或获取UserInfo！");
            }
            long userId = AbpSession.UserId.Value;

            //var userInfoRepository = IocManager.Instance.IocContainer.Resolve<IRepository<UserInfo, long>>();

            var userInfo = _userInfoRepository.Single(ui => ui.User.Id == userId);
            if (userInfo == null)
            {
                //userInfo = new UserInfo()
                //{
                //    UserId = userId,
                //};

                //userInfo = _userInfoRepository.Get(_userInfoRepository.InsertAndGetId(userInfo));
                throw new UserFriendlyException("请使用手机用户登陆！");
            }

            return userInfo;
        }

        Domain.Family.Family _family = null;
        protected Domain.Family.Family Family
        {
            get
            {
                if (_family == null)
                {
                    _family = GetOrCreateFamily();
                }             

                return _family;
            }
        }
        private Domain.Family.Family GetOrCreateFamily()
        {
            DisableFamilyDataFilter();

            if (!AbpSession.UserId.HasValue)
            {
                throw new UserFriendlyException("未登录，不能获取菜单计划！");
            }
            long userId = AbpSession.UserId.Value;
            Domain.Family.Family family = _familyResponsitory.GetByUser(userId);
            if (family == null)
            {
                throw new UserFriendlyException("请使用手机用户登陆！");
            }

            EnableFamilyDataFilter();

            return family;
        }

        //private Domain.Family.Family CreateFamily(long userId)
        //{           
        //    UserInfo.IsFamilyCreater = true;

        //    Domain.Family.Family entity = new Domain.Family.Family()
        //    {
        //        UUID = Guid.NewGuid(),
        //    };

        //    entity.UserInfos = new List<UserInfo>() { UserInfo };

        //    return _familyResponsitory.Get(_familyResponsitory.InsertAndGetId(entity));
        //}

        protected TEntityDto GetImp(EntityDto<long> input)
        {
            CheckGetPermission();

            var entity = GetEntityById(input.Id);
            return MapToEntityDto(entity);
        }       

        protected virtual TEntity GetEntityById(long id)
        {
            return Repository.Get(id);
        }

        protected TEntityDto CreateImp(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);

            Repository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }

        protected TEntityDto UpdateImp(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = GetEntityById(input.Id);

            MapToEntity(input, entity);
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(entity);
        }
    }

    public class MobileAppServiceBase<TEntity, TEntityDto>
        : MobileAppServiceBase<TEntity, TEntityDto, TEntityDto, TEntityDto>
        where TEntity : class, IEntity<long>
        where TEntityDto : IEntityDto<long>
    {
        public MobileAppServiceBase(IRepository<TEntity, long> repository) : base(repository)
        {
        }
    }

    //public class MobileCrudAppServiceBase<TEntity, TEntityDto, TCreateInput, TUpdateInput>
    //    : CrudAppService<TEntity, TEntityDto, long, PagedAndSortedResultRequestDto, TCreateInput, TUpdateInput>
    //    , IReadAppService<TEntityDto>
    //    , ICreateAppService<TEntityDto, TCreateInput>
    //    , IUpdateAppService<TEntityDto, TUpdateInput>
    //    , IDeleteAppService
    //    where TEntity : class, IEntity<long>
    //    where TEntityDto : IEntityDto<long>
    //    where TUpdateInput : IEntityDto<long>
    //{
    //    protected readonly IFamilyRepository _familyResponsitory;
    //    protected readonly IRepository<UserInfo, long> _userInfoRepository;
    //    protected MobileCrudAppServiceBase(IRepository<TEntity, long> repository) : base(repository)
    //    {

    //    }
    //}

}
