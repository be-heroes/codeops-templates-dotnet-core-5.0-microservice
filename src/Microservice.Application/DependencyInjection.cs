using CloudEngineering.CodeOps.Abstractions.Data;
using CloudEngineering.CodeOps.Abstractions.Repositories;
using CloudEngineering.CodeOps.Abstractions.Strategies;
using CloudEngineering.CodeOps.Infrastructure.EntityFramework;
using Confluent.Kafka;
using Microservice.Application.Data;
using Microservice.Application.Repositories;
using Microservice.Application.Services;
using Microservice.Application.Strategies;
using Microservice.Domain.Aggregates;
using Microservice.Domain.Repositories;
using Microservice.Domain.Services;
using Microservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Microservice.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Framework dependencies
            services.AddLogging();

            //External dependencies
            services.AddInfrastructure(configuration);

            //Application dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplicationContext(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddStrategies();
            services.AddFacade();
        }

        private static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntityContextOptions>(configuration);

            services.AddDbContext<ApplicationContext>(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var dbContextOptions = serviceProvider.GetService<IOptions<EntityContextOptions>>();
                var callingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var connectionString = dbContextOptions.Value.ConnectionStrings?.GetValue<string>(nameof(ApplicationContext));

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ApplicationFacadeException($"Could not find connection string with entry key: {nameof(ApplicationContext)}");
                }

                var dbOptions = options.UseNpgsql(connectionString,
                    sqliteOptions =>
                    {
                        sqliteOptions.MigrationsAssembly(callingAssemblyName);
                        sqliteOptions.MigrationsHistoryTable(callingAssemblyName + "_MigrationHistory");

                    }).Options;

                using var context = new ApplicationContext(dbOptions, serviceProvider.GetService<IMediator>());

                if (dbContextOptions.Value.EnableAutoMigrations)
                {
                    context.Database.Migrate();
                }
            });

            services.AddTransient<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationContext>());
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<ReportRoot>, ReportRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICostService, CostService>();
        }

        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddTransient<IStrategy<ConsumeResult<string, string>>, AwsAccountEventConsumptionStrategy>();
        }

        private static void AddFacade(this IServiceCollection services)
        {
            services.AddTransient<IApplicationFacade, ApplicationFacade>();
        }
    }
}
