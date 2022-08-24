using Microservice.Domain.Aggregates;
using Microservice.Domain.Events.Report;
using Xunit;

namespace Microservice.Domain.UnitTest.Events.Cost
{
    public class ReportCreatedEventTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ReportCreatedEvent sut;

            //Act
            sut = new ReportCreatedEvent(null);

            //Assert
            Assert.NotNull(sut);
            Assert.True(sut.ReportItem == null);
        }

        [Fact]
        public void AreNotEqual()
        {
            //Arrange
            var reportItem = new ReportRoot();
            var sut = new ReportCreatedEvent(reportItem);

            //Act
            var anotherEvent = new ReportCreatedEvent(reportItem);

            //Assert
            Assert.True(sut.ReportItem == reportItem);
            Assert.True(anotherEvent.ReportItem == reportItem);
            Assert.False(sut.Equals(anotherEvent));
        }
    }
}