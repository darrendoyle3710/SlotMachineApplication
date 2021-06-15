using Moq;
using SlotMachineApplication.Library.Interfaces;
using Frontend.Controllers;
using SlotMachineApplication.Library.Models.Binding;
using System.Collections.Generic;
using SlotMachineApplication.Library.Models;
using Microsoft.Extensions.Configuration;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace SlotMachineApplication.Tests.Controllers
{
    public class HomeControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private IConfiguration Configuration;
        private HomeController homeController;
        private Spin spin;
        private AddSpin addSpin;
        private List<Spin> spins;

        public HomeControllerTest()
        {
            spins = new List<Spin>
            {
                new Spin(){ID = 1, Animals = "dogdogcat", BonusBall = true, Prize = "$1500"},
                new Spin(){ID = 2, Animals = "tigerdogcat", BonusBall = false, Prize = "Nothing"}
            };

            addSpin = new AddSpin { Animals = "catcatdog", BonusBall = false, Prize = "$500"};

            mockRepo = new Mock<IRepositoryWrapper>();
            homeController = new HomeController(Configuration , mockRepo.Object);
        }

        [Fact]
        public void ViewSpins_Tests()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Spins.FindAll()).Returns(spins);
            //Act
            var controllerActionResult = homeController.ViewSpins();
            //Assert
            controllerActionResult.Should().NotBeNull();
            controllerActionResult.Should().BeOfType<ActionResult<IEnumerable<Spin>>>();
        }
        [Fact]
        public void Create_Tests()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Spins.FindAll()).Returns(spins);
            AddSpin newSpin = new AddSpin() { Animals = "penguinpenguinpenguin", BonusBall = true, Prize = "Ferrari" };
            //Act
            var controllerActionResult = homeController.Create(newSpin);
            //Assert
            controllerActionResult.Should().NotBeNull();
            controllerActionResult.Should().BeOfType<ActionResult<Spin>>();
        }
        [Fact]
        public void Delete_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Spins.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(spins);
            //Act
            var controllerActionResult = homeController.Delete(It.IsAny<int>());
            //Assert
            controllerActionResult.Should().NotBeNull();
            controllerActionResult.Should().BeOfType<ActionResult<Spin>>();
        }
    }
}
