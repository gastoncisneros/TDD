using FluentAssertions;
using FormulaApp.API.Controllers;
using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FormulaApp.Test.Tests.Controllers
{
    public class TestFansControllers
    {
        private readonly Mock<IFanService> _mockFanService;
        private readonly FansController _fansController;

        public TestFansControllers()
        {
            _mockFanService = new Mock<IFanService>();
            _fansController = new(_mockFanService.Object);
        }

        [Fact]
        public async Task Get_OnNoFans_ReturnsStatusCode404()
        {
            //Arrange
            _mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync([]);

            //Act
            var result = (NotFoundResult)await _fansController.Get();

            //Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Get_OnNoFans_ReturnsNotFound()
        {
            //Arrange
            _mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync([]);

            //Act
            var result = (NotFoundResult)await _fansController.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfFans()
        {
            //Arrange
            _mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync([new()]);

            //Act
            var result = (OkObjectResult)await _fansController.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<List<Fan>>();
        }

    }
}
