using Microservice.Application.Commands.Cost;
using System;
using System.Text.Json;
using Xunit;

namespace Microservice.Application.UnitTest.Commands.Cost
{
    public class UpdateCostItemCommandTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var sut = new UpdateCostItemCommand("a", "b", "c", Guid.NewGuid());
            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hashCode, sut.GetHashCode());
            Assert.True(!string.IsNullOrEmpty(sut.CapabilityIdentifier));
            Assert.True(!string.IsNullOrEmpty(sut.Label));
            Assert.True(!string.IsNullOrEmpty(sut.Value));
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new UpdateCostItemCommand("a", "b", "c", Guid.NewGuid());

            //Act
            var json = JsonSerializer.Serialize(sut);

            //Assert
            Assert.False(string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Arrange
            UpdateCostItemCommand sut;
            var json = "{\"capabilityIdentifier\": \"a\", \"label\": \"b\", \"value\": \"c\"}";

            //Act
            sut = JsonSerializer.Deserialize<UpdateCostItemCommand>(json);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("a", sut.CapabilityIdentifier);
            Assert.Equal("b", sut.Label);
            Assert.Equal("c", sut.Value);
        }
    }
}