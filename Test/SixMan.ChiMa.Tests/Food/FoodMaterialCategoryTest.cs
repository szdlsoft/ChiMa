﻿using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Application.Food.Dto;
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

        public FoodMaterialCategoryTest()
        {
            _appService = Resolve<IFoodMaterialCategoryAppService>();
        }

        [Fact]
        public async Task GetFoodMaterialCategory_Test()
        {
            // Act
            var output = await _appService.GetAll(new PagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
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
    }
}
