using CloudEngineering.CodeOps.Infrastructure.EntityFramework.Repositories;
using Microservice.Application.Data;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microservice.Application.Repositories
{
    public class ReportRepository : EntityFrameworkRepository<ReportRoot, ApplicationContext>, IReportRepository
    {
        public ReportRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ReportRoot>> GetAsync(Expression<Func<ReportRoot, bool>> filter)
        {
            return await Task.Factory.StartNew(() =>
            {
                return _context.ReportItems.AsQueryable()
                                            .AsNoTracking()
                                            .Where(filter)
                                            .Include(i => i.CostItems)
                                            .AsEnumerable();
            });
        }

        public async Task<ReportRoot> GetAsync(Guid reportItemId)
        {
            var reportItem = await _context.ReportItems.FindAsync(reportItemId);

            if (reportItem != null)
            {
                var entry = _context.Entry(reportItem);

                if (entry != null)
                {
                    await entry.Reference(i => i.CostItems).LoadAsync();
                }
            }

            return reportItem;
        }
    }
}