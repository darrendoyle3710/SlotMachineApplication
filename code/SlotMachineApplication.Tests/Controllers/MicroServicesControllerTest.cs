using Colour.Controllers;
using FluentAssertions;
using Merge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme.Controllers;
using Xunit;

namespace SlotMachineApplication.Tests.Controllers
{
    public class MicroServicesControllerTest
    {
        private AnimalsController animalsController;
        private BonusNumberController bonusnumberController;
        private MergeController mergeController;
        private IConfiguration Configuration;

        public MicroServicesControllerTest()
        {
            animalsController = new AnimalsController();
            bonusnumberController = new BonusNumberController();
            mergeController = new MergeController(Configuration);
        }

        [Fact]
        public void Animals_Tests()
        {
            //Act
            var controllerActionResult = animalsController.Get();
            //Assert
            controllerActionResult.Should().NotBeNull();
            controllerActionResult.Should().BeOfType<string>();
        }
        [Fact]
        public void Bonus_Tests()
        {
            //Act
            var controllerActionResult = bonusnumberController.Get();
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

        [Fact]
        public void Merge_Tests()
        {
            //Act
            var controllerActionResult = mergeController.Get();
            //var getPrizeResult = mergeController.GetPrize("dogdogcat","4",3);
            //Assert
            controllerActionResult.Should().NotBeNull();
            controllerActionResult.Should().BeOfType<Task<IActionResult>>();
            //getPrizeResult.Should().BeOfType<string>();
            //Assert.Equal($@"{{'Animals':'dogdogcat','Number':'4','Prize':'$1500','Bonus':'4'}}",getPrizeResult);
        
        }
    }
}
