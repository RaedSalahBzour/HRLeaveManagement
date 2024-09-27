using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRLeaveManagement.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //or this for a specific file
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
