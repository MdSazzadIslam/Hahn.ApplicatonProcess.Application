using Hahn.ApplicatonProcess.December2020.Data.Common.Behaviours;
using Hahn.ApplicatonProcess.December2020.Data.Common.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Handlers;
using Hahn.ApplicatonProcess.December2020.Data.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Hahn.ApplicatonProcess.December2020.Data.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Transient lifetime services are created each time they are requested.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient<IDateTime, DateTimeService>();

            //Scoped lifetime services are created once per request within the scope.It is equivalent to a singleton in the current scope.
            services.AddScoped<IApplicantReadService, ApplicantReadService>();
            services.AddScoped<IApplicantWriteService, ApplicantWriteService>();
            return services;
        }
           
    }
}
