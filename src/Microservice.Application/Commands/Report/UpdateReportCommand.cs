using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Aggregates;
using System.Text.Json.Serialization;

namespace Microservice.Application.Commands.Report
{
    public sealed class UpdateReportCommand : ICommand<ReportRoot>
    {
        [JsonPropertyName("report")]
        public ReportRoot Report { get; init; }

        [JsonConstructor]
        public UpdateReportCommand(ReportRoot report)
        {
            Report = report;
        }
    }
}