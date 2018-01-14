using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Dish;
using System.Linq;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Application.Extensions;

namespace SixMan.ChiMa.Application.Dish.Imp
{
    public class DishDetailsAppService
        : MobileAppServiceBase<Domain.Dish.Dish, DishDetailsDto>
        , IDishDetailsAppService
    {
        IRepository<CookeryNote, long> _cookeryNoteRepositor;
        public DishDetailsAppService(IDishRepository repository
                                    ,IRepository<CookeryNote, long> cookeryNoteRepository)
            : base(repository)
        {
            _cookeryNoteRepositor = cookeryNoteRepository;
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

        public CookeryNoteDto CreateCookeryNote(CookeryNoteCreateDto CookeryNote)
        {
            throw new NotImplementedException();
        }
    }
}
