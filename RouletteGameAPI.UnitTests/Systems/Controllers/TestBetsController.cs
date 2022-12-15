using Services.Contracts;
using RouletteGameRestApi.PresetantionLayer.Controllers;
using RouletteGameAPI.UnitTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace RouletteGameAPI.UnitTests.Systems.Controllers
{
    public class TestBetsController
    {
        [Fact]
        public async Task GetAllAsync_InvockesPlaceBetRepositoryExactlyOnce()
        {
            // Arrange
            var betService = new Mock<IServiceManager>();
            betService.Setup(_ => _.BetService.GetBetAsync(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), false))
                .ReturnsAsync(BetsFixture.GetBet(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")));

            var sut = new BetsController(betService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetBet(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            //Assert 
            betService.Verify(service => service.BetService.GetBetAsync(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), false), Times.Once());
        }

        [Fact]
        public async Task GetSpinAsync_ShouldReturn200Status()
        {
            //Arrange
            var betService = new Mock<IServiceManager>();
            betService.Setup(_ => _.BetService.GetBetAsync(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), false))
                .ReturnsAsync(BetsFixture.GetBet(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")));

            var sut = new BetsController(betService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetBet(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            //Assert 
            result.StatusCode.Should().Be(200);
        }
    }
}
