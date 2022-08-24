using CloudEngineering.CodeOps.Abstractions.Facade;
using MediatR;

namespace Microservice.Application
{
    public sealed class ApplicationFacade : Facade, IApplicationFacade
    {
        public ApplicationFacade(IMediator mediator) : base(mediator)
        {
        }
    }
}