using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using O2NextGen.CertificateManagement.Domain.Data;
using System.Text.RegularExpressions;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Domain.Data.Queries;

namespace Microsoft.Extensions.DependencyInjection
    {
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddBusiness(this IServiceCollection services)
            {
                services.AddMediatR(
                    typeof(GetCertificateQuery));

                return services;
            }

        public static TConfig ConfigurePOCO<TConfig>(this IServiceCollection services, IConfiguration configuration)
           where TConfig : class, new()
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();
            configuration.Bind(config);
            services.AddSingleton(config);
            return config;
        }

        public static IServiceCollection AddConfigEf(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<CertificateManagementDbContext>(x =>
                x.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddSingleton<ICurrentUserAccessor, CurrentUserAccessor>();

            services.Scan(scan =>
                scan
                    .FromAssembliesOf(typeof(CertificateManagementDbContext))
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                );

            // without Scrutor (or an alternative) we'd need to do everything by hand, like:
            /*
                services.AddScoped<IRepository<Group, long>, EfRepository<Group, long>>();
                services.AddScoped<IRepository<User, string>, EfRepository<User, string>>();
                services.AddScoped<IQueryHandler<UserGroupsQuery, IReadOnlyCollection<Group>>, UserGroupsQueryHandler>();
                services.AddScoped<IQueryHandler<UserGroupQuery, Group>, UserGroupQueryHandler>();
                // ...
            */
            return services;
        }
    }
    
}

