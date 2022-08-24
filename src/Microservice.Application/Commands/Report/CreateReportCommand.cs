using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Aggregates;
using Microservice.Domain.ValueObjects;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microservice.Application.Commands.Report
{
    public sealed class CreateReportCommand : ICommand<ReportRoot>
    {
        [JsonPropertyName("costItems")]
        public IEnumerable<CostItem> CostItems { get; init; }

        [JsonConstructor]
        public CreateReportCommand(IEnumerable<CostItem> costItems)
        {
            CostItems = costItems;
        }
    }
}