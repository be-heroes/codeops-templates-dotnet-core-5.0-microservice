using Microservice.Application.Commands.Cost;
using Microservice.Domain.Services;
using Moq;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Cost
{
    public class UpdateCostItemCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange            
            var mockCostService = new Mock<ICostService>();
            var sut = new UpdateCostItemCommandHandler(mockCostService.Object);

            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.Equal(hashCode, sut.GetHashCode());
            Assert.NotNull(sut);

            Mock.VerifyAll();
        }
    }
}