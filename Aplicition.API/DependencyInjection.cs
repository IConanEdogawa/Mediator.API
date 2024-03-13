using Mediator.Applicition.Abstractions.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator.Applicition
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }

    }
}
