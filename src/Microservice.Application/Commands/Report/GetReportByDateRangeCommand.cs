using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microservice.Application.Commands.Report
{
    public sealed class GetReportByDateRangeCommand : ICommand<IEnumerable<ReportRoot>>
    {
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; init; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; init; }

        [JsonConstructor]
        public GetReportByDateRangeCommand(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}