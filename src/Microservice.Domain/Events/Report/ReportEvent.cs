using CloudEngineering.CodeOps.Abstractions.Events;
using Microservice.Domain.Aggregates;

namespace Microservice.Domain.Events.Report
{
    public abstract class ReportEvent : IDomainEvent
    {
        public ReportRoot ReportItem { get; protected set; }
    }
}