using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Services;
using Microservice.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Commands.Cost
{
    public sealed class UpdateCostItemCommandHandler : ICommandHandler<UpdateCostItemCommand, CostItem>
    {
        private readonly ICostService _costService;

        public UpdateCostItemCommandHandler(ICostService costService)
        {
            _costService = costService ?? throw new ArgumentNullException(nameof(costService));
        }

        public async Task<CostItem> Handle(UpdateCostItemCommand command, CancellationToken cancellationToken = default)
        {
            var report = await _costService.AddOrUpdateCostItemAsync(command.ReportItemId, command.CapabilityIdentifier, command.Label, command.Value, cancellationToken);

            return report;
        }
    }
}