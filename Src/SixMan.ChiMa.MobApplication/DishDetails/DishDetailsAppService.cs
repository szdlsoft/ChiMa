using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System.Linq;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Extensions;
using Abp.Authorization;
using Abp.Web.Models;
using Abp.UI;

namespace SixMan.ChiMa.Application.Dish.Imp
{
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    [Abp.Authorization.AbpAuthorize]
    public class DishDetailsAppService
        : MobileAppServiceBase<Domain.Dish.Dish, DishDetailsDto>
        , IDishDetailsAppService
    {
        IRepository<CookeryNote, long> _cookeryNoteRepository;
        IRepository<Cookery, long> _cookeryRepository;
        public DishDetailsAppService(IDishRepository repository
                                    ,IRepository<CookeryNote, long> cookeryNoteRepository
                                    ,IRepository<Cookery, long> cookeryRepository
                                    )
            : base(repository)
        {
            _cookeryNoteRepository = cookeryNoteRepository;
            _cookeryRepository = cookeryRepository;
        }

        IDishRepository dishRepository => Repository as IDishRepository;

        protected override Domain.Dish.Dish GetEntityById(long id)
        {
            //return Repository.GetAllIncluding( d => d.DishBoms
            //                                  , d => d.Cookerys)
            //                 .Where(d => d.Id == id)
            //                 .FirstOrDefault();
            return dishRepository.GetWithDetails(id);
        }

        protected override DishDetailsDto MapToEntityDto(Domain.Dish.Dish entity)
        {
            if( entity == null)
            {
                throw new Exception($"找不到指定的dish");
            }           

            var dto = base.MapToEntityDto(entity);
            dto.DishBoms.Map(db => db.FoodMaterialName = 
                            entity.DishBoms.FirstOrDefault(dd => dd.Id == db.Id).FoodMaterial.Description);

            CaculateNutritionSum(dto, entity.DishBoms);
            // 烹饪步骤没有文字说明bug , 导入时写死了abc
            foreach( var cookery in dto.Cookerys)
            {
                cookery.Description = cookery.Content;
            }


            return dto;
        }

        private void CaculateNutritionSum(DishDetailsDto dto, ICollection<DishBom> dishBoms)
        {
            dto.Nutritions = new List<NutritionDto>()//暂时写死
            {
                new NutritionDto(){Name = NutritionName.卡路里.ToString(), Volume = 1}
                ,new NutritionDto(){Name = NutritionName.胆固醇.ToString(), Volume = 2}
                ,new NutritionDto(){Name = NutritionName.脂肪.ToString(), Volume = 3}
                ,new NutritionDto(){Name = NutritionName.膳食纤维.ToString(), Volume = 4}
                ,new NutritionDto(){Name = NutritionName.蛋白质.ToString(), Volume = 5}
                ,new NutritionDto(){Name = NutritionName.钙.ToString(), Volume = 6}
                ,new NutritionDto(){Name = NutritionName.钠.ToString(), Volume = 7}
                ,new NutritionDto(){Name = NutritionName.钾.ToString(), Volume = 8}
            };         
            
        }

        public CookeryNoteDto CreateCookeryNote(CookeryNoteCreateDto CookeryNoteDto)
        {
            EnsureCookId(CookeryNoteDto.CookeyId);
            var note = new CookeryNote()
            {
                CookeryId = CookeryNoteDto.CookeyId,
                UserInfoId = UserInfo.Id,
                Description = CookeryNoteDto.Description
            };

            return ObjectMapper.Map<CookeryNoteDto>( _cookeryNoteRepository.Get( _cookeryNoteRepository.InsertAndGetId(note)));
        }

        private void EnsureCookId(long cookeyId)
        {
            if(_cookeryRepository.Get(cookeyId) == null)
            {
                throw new UserFriendlyException($"id={cookeyId} 的烹饪步骤不存在！");
            }
        }      

        public DishDetailsDto Get(EntityDto<long> input)
        {
            return GetImp(input);
        }
    }
}
