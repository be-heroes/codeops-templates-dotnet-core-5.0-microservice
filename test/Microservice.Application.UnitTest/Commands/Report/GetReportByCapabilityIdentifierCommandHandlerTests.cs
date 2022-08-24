using Microservice.Application.Commands.Report;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Services;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Report
{
    public class GetReportByCapabilityIdentifierCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var mockCostService = new Mock<ICostService>();
            var sut = new GetReportByCapabilityIdentifierCommandHandler(mockCostService.Object);

            //Act
            var result = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(result, sut.GetHashCode());

            Mock.VerifyAll();
        }

        [Fact]
        public async Task CanHandleCommand()
        {
            //Arrange
            var mockCostService = new Mock<ICostService>();
            var sut = new GetReportByCapabilityIdentifierCommandHandler(mockCostService.Object);

            mockCostService
                .Setup(m => m.GetReportByCapabilityIdentifierAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Enumerable.Empty<ReportRoot>()));

            //Act
            var result = await sut.Handle(new GetReportByCapabilityIdentifierCommand("a"));

            //Assert
            Assert.True(result != null);
            Assert.Empty(result);

            Mock.VerifyAll();
        }
    }
}