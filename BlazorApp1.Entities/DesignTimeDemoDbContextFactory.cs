using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorApp1.Entities
{
    public class DesignTimeDemoDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
    {
        public DemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            // point to a design-time database separate from local-development database
            builder.UseSqlite("Data Source=reference.db");
            return new DemoDbContext(builder.Options);
        }
    }
}
