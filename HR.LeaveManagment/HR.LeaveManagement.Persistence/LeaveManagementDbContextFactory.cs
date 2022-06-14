using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence
{
    public class LeaveManagementDbContextFactory :
        IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = config.GetConnectionString("LeaveManagementConnectionString");
            builder.UseSqlServer(connectionString);

            return new LeaveManagementDbContext(builder.Options);
        }
    }
}
