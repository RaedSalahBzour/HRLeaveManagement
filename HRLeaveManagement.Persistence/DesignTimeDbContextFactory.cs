using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRLeaveManagement.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HRLeaveManagementDbContext>
    {
        public HRLeaveManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRLeaveManagementDbContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new HRLeaveManagementDbContext(optionsBuilder.Options);
        }
    }
}
