using Microservice.Application.Commands.Report;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Services;
using Microservice.Domain.ValueObjects;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Report
{
    public class CreateReportCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange            
            var mockCostService = new Mock<ICostService>();
            var sut = new CreateReportCommandHandler(mockCostService.Object);

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
            var fakeReportItem = new ReportRoot();

            mockCostService.Setup(m => m.AddReportAsync(It.IsAny<IEnumerable<CostItem>>(), It.IsAny<CancellationToken>()))
                            .Returns(Task.FromResult(fakeReportItem));

            var sut = new CreateReportCommandHandler(mockCostService.Object);

            //Act
            var result = await sut.Handle(new CreateReportCommand(new List<CostItem>()));

            //Assert
            Assert.Equal(result, fakeReportItem);

            Mock.VerifyAll();
        }
    }
}