using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persistence.Reopsitories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceServicesRegisteration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRLeaveManagementDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
    public class HRLeaveManagementDbContextFactory : IDesignTimeDbContextFactory<HRLeaveManagementDbContext>
    {
        public HRLeaveManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRLeaveManagementDbContext>();
            optionsBuilder.UseSqlServer("ConnectionString");

            return new HRLeaveManagementDbContext(optionsBuilder.Options);
        }
    }
}
