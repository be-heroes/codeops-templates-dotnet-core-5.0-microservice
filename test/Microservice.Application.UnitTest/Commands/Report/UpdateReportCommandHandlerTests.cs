using Microservice.Application.Commands.Report;
using Microservice.Domain.Services;
using Moq;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Report
{
    public class UpdateReportCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange            
            var mockCostService = new Mock<ICostService>();
            var sut = new UpdateReportCommandHandler(mockCostService.Object);

            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.Equal(hashCode, sut.GetHashCode());
            Assert.NotNull(sut);

            Mock.VerifyAll();
        }
    }
}