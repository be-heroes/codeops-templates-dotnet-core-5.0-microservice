using AutoMapper;
using Microservice.Application.Events.Report;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Events.Report;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Application.UnitTest.Events.Report
{
    public class ReportCreatedEventHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();
            var sut = new ReportCreatedEventHandler(mockMapper.Object, mockMediator.Object);

            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hashCode, sut.GetHashCode());

            Mock.VerifyAll();
        }

        [Fact]
        public async Task CanHandleEvent()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();
            var sut = new ReportCreatedEventHandler(mockMapper.Object, mockMediator.Object);

            //Act
            await sut.Handle(new ReportCreatedEvent(new ReportRoot()));

            //Assert
            Mock.VerifyAll();
        }
    }
}