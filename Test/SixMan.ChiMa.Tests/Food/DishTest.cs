using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Application.Food.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SixMan.ChiMa.Tests.Food
{
    public class DishTest : ChiMaTestBase
    {
        private readonly IDishAppService _appService;
        private readonly IFoodMaterialAppService _foodMaterialAppService;

        public DishTest()
        {
            _appService = Resolve<IDishAppService>();
            _foodMaterialAppService = Resolve<IFoodMaterialAppService>();
        }

        [Fact]
        public async Task GetDish_Test()
        {
            // Act
            var output = await _appService.GetAll(new SortSearchPagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async Task CreateDish_Test()
        {
            // Act
            await _appService.Create(
                new DishDto
                {
                    Description="johnNash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashDish = await context.Dish.FirstOrDefaultAsync(u => u.Description == "johnNash");
                johnNashDish.ShouldNotBeNull();                
            });
        }

        [Fact]
        public async Task CreateDish_WithDisBom_Test()
        {
            await _foodMaterialAppService.Create(new FoodMaterialDto()
            {
               Description = "foodMaterial001"

            });

            var foodMaterial = _foodMaterialAppService.GetAll(new SortSearchPagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 })
                .Result.Items[0];



            DishBomDto bom = new DishBomDto()
            {
                Id = 1,
                FoodMaterialId = foodMaterial.Id,
            };

            DishDto dish = new DishDto
                {
                    Description = "johnNash",
                    DishBoms = new List<DishBomDto>()
                    {
                        bom
                    }
                };

            // Act
            var dtoTemp = await _appService.Create(dish);
               
            await UsingDbContextAsync(async context =>
            {
                var johnNashDish = await context.Dish.FirstOrDefaultAsync(u => u.Description == "johnNash");
                johnNashDish.ShouldNotBeNull();
            });

            var output = await _appService.GetAll(new SortSearchPagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            output.Items.Count.ShouldBeGreaterThan(0);
            var dishOutput = output.Items[0];
            dishOutput.ShouldNotBeNull();
            dishOutput.DishBoms.ShouldNotBeNull();
            dishOutput.DishBoms.Count.ShouldBeGreaterThan(0);

            Console.WriteLine(output);

        }
    }
}
