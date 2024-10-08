using Microservice.Infrastructure.CostProviders.Aws;
using Microservice.Infrastructure.IntegrationTest.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.Infrastructure.IntegrationTest.CostProviders.Aws
{
    public class AwsCostClientTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _awsFixture;

        public AwsCostClientTests(AwsFacadeFixture fixture)
        {
            _awsFixture = fixture;
        }

        [Fact]
        public async Task GetMonthlyTotalCostAllAccountsTest()
        {
            var facade = _awsFixture.Facade;
            var sut = new AwsCostClient(facade);
            var resp = await sut.GetMonthlyTotalCostAllAccountsAsync();

            Assert.NotNull(resp);

            foreach (var result in resp)
            {
                Assert.NotEmpty(result.ResultsByTime);
                Assert.NotEmpty(result.DimensionValueAttributes);
            }
        }

        [Fact]
        public async Task GetMonthlyTotalCostsByAccountId()
        {
            var facade = _awsFixture.Facade;
            var sut = new AwsCostClient(facade);
            var resp = await sut.GetMonthlyTotalCostByAccountIdAsync("642375522597");

            Assert.NotEmpty(resp.ResultsByTime);
        }
    }
}