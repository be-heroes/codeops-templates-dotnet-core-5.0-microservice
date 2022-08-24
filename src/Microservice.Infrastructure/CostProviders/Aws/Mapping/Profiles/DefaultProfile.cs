using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using Microservice.Domain.Aggregates;
using Microservice.Infrastructure.CostProviders.Aws.Mapping.Converters;

namespace Microservice.Infrastructure.CostProviders.Aws.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<CostDto, ReportRoot>()
            .ConvertUsing<CostDtoToReportRootConverter>();
        }
    }
}
