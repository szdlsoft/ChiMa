using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SixMan.ChiMa.Tests.Food
{
    public class FoodMaterialCategoryTest : ChiMaTestBase
    {
        private readonly IFoodMaterialCategoryAppService _appService;
        private readonly FoodMaterialManager _importManager;
        private IRepository<FoodMaterialCategory, long> _foodMaterialCategoryRepository;

        public FoodMaterialCategoryTest()
        {
            _appService = Resolve<IFoodMaterialCategoryAppService>();
            _importManager = Resolve<FoodMaterialManager>();
            _foodMaterialCategoryRepository = Resolve<IRepository<FoodMaterialCategory, long>>();
        }

        [Fact]
        public async Task GetFoodMaterialCategory_Test()
        {
            // Act
            var output = await _appService.GetAll(new SortSearchPagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _appService.Create(
                new FoodMaterialCategoryDto
                {
                    Name="111"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.FoodMaterialCategory.FirstOrDefaultAsync(u => u.Name == "111");
                johnNashUser.ShouldNotBeNull();

                
            });
        }

        [Fact]
        public void CreateFoodMaterialCategory_Test()
        {
            _foodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
            {
                Name = "ABC"
            });

            var entity = _foodMaterialCategoryRepository.FirstOrDefault(f => f.Name == "ABC");

            _foodMaterialCategoryRepository.Delete(entity);
        }
    }
}
