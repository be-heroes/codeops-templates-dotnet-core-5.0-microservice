﻿using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices;
using CloudEngineering.CodeOps.Infrastructure.Kafka;
using CloudEngineering.CodeOps.Security.Policies;
using Microservice.Infrastructure.CostProviders.Aws;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservice.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //External dependencies
            services.AddAmazonWebServices(configuration);
            services.AddKafka(configuration);
            services.AddSecurityPolicies();

            //Package dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAwsCostClient();
        }

        private static void AddAwsCostClient(this IServiceCollection services)
        {
            services.AddTransient<IAwsCostClient, AwsCostClient>();
        }
    }
}
