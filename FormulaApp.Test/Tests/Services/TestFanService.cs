using FluentAssertions;
using FormulaApp.API.Configurations;
using FormulaApp.API.Models;
using FormulaApp.API.Services;
using FormulaApp.Test.Fixtures;
using FormulaApp.Test.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Test.Tests.Services
{
    public class TestFanService
    {
        [Fact]
        public async Task GetAllFans_OnInvoked_HttpGet()
        {
            //Arrange
            var url = "https://myTest.com/api/v1/fans";
            List<Fan> response = FansFixtures.GetFans();
            Mock<HttpMessageHandler> mockHttpHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            HttpClient client = new HttpClient(mockHttpHandler.Object);
            var apiConfig = Options.Create(new ApiServiceConfiguration()
            {
                Url = url
            });

            FanService fanService = new FanService(client, apiConfig);

            //Act
            await fanService.GetAllFans();

            //Assert
            mockHttpHandler.Protected().Verify("SendAsync", 
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetAllFans_OnInvoked_ListOfFans()
        {
            //Arrange
            var url = "https://myTest.com/api/v1/fans";
            List<Fan> response = FansFixtures.GetFans();
            Mock<HttpMessageHandler> mockHttpHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            HttpClient client = new HttpClient(mockHttpHandler.Object);
            var apiConfig = Options.Create(new ApiServiceConfiguration()
            {
                Url = url
            });

            FanService fanService = new FanService(client, apiConfig);

            //Act
            List<Fan>? fans = await fanService.GetAllFans();

            //Assert
            fans.Should().BeOfType<List<Fan>>();
            fans.Should().NotBeNull();
            fans.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetAllFans_OnInvoked_ReturnEmptyList()
        {
            //Arrange
            var url = "https://myTest.com/api/v1/fans";
            Mock<HttpMessageHandler> mockHttpHandler = MockHttpHandler<Fan>.SetupNotFoundRequest();
            HttpClient client = new HttpClient(mockHttpHandler.Object);
            var apiConfig = Options.Create(new ApiServiceConfiguration()
            {
                Url = url
            });

            FanService fanService = new FanService(client, apiConfig);

            //Act
            List<Fan>? fans = await fanService.GetAllFans();

            //Assert
            fans.Should().BeEmpty();
        }
    }
}
