using CloudEngineering.CodeOps.Abstractions.Commands;
using System;
using System.Text.Json.Serialization;

namespace Microservice.Application.Commands.Report
{
    public sealed class DeleteReportCommand : ICommand<bool>
    {
        [JsonPropertyName("reportId")]
        public Guid ReportId { get; init; }

        [JsonConstructor]
        public DeleteReportCommand(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}