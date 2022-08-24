using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Abstractions.Commands;
using Microservice.Application.Commands.Report;
using Microservice.Domain.Aggregates;
using System;

namespace Microservice.Application.Mapping.Converters
{
    public class AggregateRootToCommandConverter : ITypeConverter<IAggregateRoot, ICommand<IAggregateRoot>>
    {
        public ICommand<IAggregateRoot> Convert(IAggregateRoot source, ICommand<IAggregateRoot> destination = default, ResolutionContext context = default)
        {
            switch (source)
            {
                case ReportRoot report:
                    if (report.Id == Guid.Empty)
                    {
                        destination = new CreateReportCommand(report.CostItems);
                    }
                    else
                    {
                        destination = new UpdateReportCommand(report);
                    }

                    break;
                case null:
                default:
                    break;
            }

            return destination;
        }
    }
}
