using SixMan.ChiMa.Application.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SixMan.ChiMa.Tests.Dish
{
    public class PlanAppServieTest
        : ChiMaTestBase
    {
        private readonly IPlanAppService _appService;

        public PlanAppServieTest()
        {
            _appService = Resolve<IPlanAppService>();
        }

        [Fact]
        public void GetByDate_Test()
        {
            var plans = _appService.GetByDate(DateTime.Parse("2018-01-13"));

        }


    }
}
