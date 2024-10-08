using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Commands.Report
{
    public sealed class GetReportByDateRangeCommandHandler : ICommandHandler<GetReportByDateRangeCommand, IEnumerable<ReportRoot>>
    {
        private readonly ICostService _costService;

        public GetReportByDateRangeCommandHandler(ICostService costService)
        {
            _costService = costService ?? throw new ArgumentNullException(nameof(costService));
        }

        public async Task<IEnumerable<ReportRoot>> Handle(GetReportByDateRangeCommand command, CancellationToken cancellationToken = default)
        {
            var reports = await _costService.GetReportByDateRangeAsync(command.StartDate, command.EndDate, cancellationToken);

            return reports;
        }
    }
}