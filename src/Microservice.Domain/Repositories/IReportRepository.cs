using CloudEngineering.CodeOps.Abstractions.Repositories;
using Microservice.Domain.Aggregates;
using System;
using System.Threading.Tasks;

namespace Microservice.Domain.Repositories
{
    public interface IReportRepository : IRepository<ReportRoot>
    {
        Task<ReportRoot> GetAsync(Guid reportItemId);
    }
}