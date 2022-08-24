using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Commands.Report
{
    public sealed class DeleteReportCommandHandler : ICommandHandler<DeleteReportCommand, bool>
    {
        private readonly ICostService _costService;

        public DeleteReportCommandHandler(ICostService costService)
        {
            _costService = costService ?? throw new ArgumentNullException(nameof(costService));
        }

        public async Task<bool> Handle(DeleteReportCommand command, CancellationToken cancellationToken = default)
        {
            var report = await _costService.DeleteReportAsync(command.ReportId, cancellationToken);

            return report;
        }
    }
}