using Microservice.Domain.Aggregates;

namespace Microservice.Domain.Events.Report
{
    public sealed class ReportCreatedEvent : ReportEvent
    {
        public ReportCreatedEvent(ReportRoot reportItem)
        {
            ReportItem = reportItem;
        }
    }
}