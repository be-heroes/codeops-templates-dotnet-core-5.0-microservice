﻿using Microservice.Infrastructure.CostProviders.Aws.Mapping.Profiles;
using Xunit;

namespace Microservice.Infrastructure.UnitTest.CostProviders.Aws.Mapping.Profiles
{
    public class DefaultProfileTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            DefaultProfile sut;

            //Act
            sut = new DefaultProfile();

            //Assert
            Assert.NotNull(sut);
        }
    }
}
