using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Commands.Report
{
    public sealed class CreateReportCommandHandler : ICommandHandler<CreateReportCommand, ReportRoot>, ICommandHandler<CreateReportCommand, IAggregateRoot>
    {
        private readonly ICostService _costService;

        public CreateReportCommandHandler(ICostService costService)
        {
            _costService = costService ?? throw new ArgumentNullException(nameof(costService));
        }

        public async Task<ReportRoot> Handle(CreateReportCommand command, CancellationToken cancellationToken = default)
        {
            var report = await _costService.AddReportAsync(command.CostItems, cancellationToken);

            return report;
        }

        async Task<IAggregateRoot> IRequestHandler<CreateReportCommand, IAggregateRoot>.Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            return await Handle(request, cancellationToken);
        }

        async Task<IAggregateRoot> ICommandHandler<CreateReportCommand, IAggregateRoot>.Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            return await Handle(request, cancellationToken);
        }
    }
}