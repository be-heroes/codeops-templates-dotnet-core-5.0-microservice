using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Commands.Cost
{
    public sealed class DeleteCostItemCommandHandler : ICommandHandler<DeleteCostItemCommand, bool>
    {
        private readonly ICostService _costService;

        public DeleteCostItemCommandHandler(ICostService costService)
        {
            _costService = costService ?? throw new ArgumentNullException(nameof(costService));
        }

        public async Task<bool> Handle(DeleteCostItemCommand command, CancellationToken cancellationToken = default)
        {
            var report = await _costService.DeleteCostItemAsync(command.ReportItemId, command.Label, command.CapabilityIdentifier, cancellationToken);

            return report;
        }
    }
}