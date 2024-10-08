using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Events;
using Microservice.Domain.Events.Report;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Application.Events.Report
{
    public sealed class ReportCreatedEventHandler : IEventHandler<ReportCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReportCreatedEventHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Handle(ReportCreatedEvent @event, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(_mapper.Map<ReportCreatedIntegrationEvent>(@event), cancellationToken);
        }
    }
}