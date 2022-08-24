using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Infrastructure.CostProviders.Aws
{
    public interface IAwsCostClient : ICostProvider, IDisposable
    {
        Task<IEnumerable<CostDto>> GetMonthlyTotalCostAllAccountsAsync();

        Task<CostDto> GetMonthlyTotalCostByAccountIdAsync(string accountId);
    }
}