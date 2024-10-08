using Microservice.Application.Commands.Cost;
using Microservice.Domain.Services;
using Microservice.Domain.ValueObjects;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Cost
{
    public class CreateCostItemCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange            
            var mockCostService = new Mock<ICostService>();
            var sut = new CreateCostItemCommandHandler(mockCostService.Object);

            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.Equal(hashCode, sut.GetHashCode());
            Assert.NotNull(sut);

            Mock.VerifyAll();
        }

        [Fact]
        public async Task CanHandleCommand()
        {
            //Arrange
            var mockCostService = new Mock<ICostService>();
            var costItem = new CostItem("b", "c", "a");

            mockCostService.Setup(m => m.AddOrUpdateCostItemAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), new CancellationToken())).Returns(Task.FromResult(costItem));

            var sut = new CreateCostItemCommandHandler(mockCostService.Object);

            //Act
            var result = await sut.Handle(new CreateCostItemCommand("a", "b", "c", Guid.NewGuid()));

            //Assert
            Assert.Equal(result, costItem);

            Mock.VerifyAll();
        }
    }
}