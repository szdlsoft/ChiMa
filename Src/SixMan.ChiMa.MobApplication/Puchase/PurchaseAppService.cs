using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Linq;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Base;

namespace SixMan.ChiMa.Application
{
    public class PurchaseAppService
        : MobileAppServiceBase<Purchase, PurchaseDto, PurchaseCreateDto,PurchaseUpdateDto>
        , IPurchaseAppService
    {
        IPlanRepository _planRepository;
        public PurchaseAppService(IRepository<Purchase, long> repository
                                  ,IPlanRepository planRepository) 
            : base(repository)
        {
            _planRepository = planRepository;
        }

        protected override Purchase MapToEntity(PurchaseCreateDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            if( entity.Family == null)
            {
                entity.Family = Family;
            }
            return entity;
        }

        public PurchaseDto Create(PurchaseCreateDto input)
        {
            return CreateImp(input);
        }
        public PurchaseDto Update(PurchaseUpdateDto input)
        {
            return UpdateImp(input);
        }

        public IList<PurchaseDto> GetByDateRange(DateRange dateRange)
        {
            //需求 = 计划
            //已烧掉？
            //库存 = 采购已执行-已烧掉
            //采购未执行
            //采购 = 计划 - (采购未执行 + 库存）
            //采购 = 计划 - (采购未执行 + 采购已执行-已烧掉）= 计划 - （采购 - 已烧掉）
            //已烧掉TBD， 这样 采购 =计划 - 采购；

            //计划
            IList<FoodMaterialVolume> plan = _planRepository.GetByRange(Family.Id, dateRange);
            //原采购
            IList<FoodMaterialVolume> purchase = Repository.GetAllIncluding( p => p.FoodMaterial)
                                     .Where(p => p.Family.Id == Family.Id)
                                     .Select( p =>new FoodMaterialVolume()
                                     {
                                         FoodMaterial=p.FoodMaterial,
                                         Volume = p.Volume
                                     })

                                     .ToList();
            //新采购
            IList<FoodMaterialVolume> newPurchase = GeneratePurchase(plan, purchase);
            //
            foreach( var np in newPurchase)
            {
                Repository.Insert(new Purchase()
                {
                    Family = Family,
                    FoodMaterial = np.FoodMaterial,
                    Volume = np.Volume,
                });
            }


            var result = Repository.GetAllIncluding(p => p.FoodMaterial
                                                 , p => p.FoodMaterial.FoodMaterialCategory)
                                     .Where(p => p.Family.Id == Family.Id)
                                     .Select(MapToEntityDto).ToList();

            return result;
        }

        private IList<FoodMaterialVolume> GeneratePurchase(IList<FoodMaterialVolume> plan, IList<FoodMaterialVolume> purchase)
        {
            List<FoodMaterialVolume> newPurchase = new List<FoodMaterialVolume>();
            foreach( var planFmv in plan)
            {
                var p = purchase.FirstOrDefault(pc => pc.FoodMaterial.Id == planFmv.FoodMaterial.Id);
                if( p == null)
                {
                    newPurchase.Add(planFmv); //没有就增加
                }
                else
                {
                    //如果有，但数量不足TBD
                }
            }

            return newPurchase;
        }
    }
}
