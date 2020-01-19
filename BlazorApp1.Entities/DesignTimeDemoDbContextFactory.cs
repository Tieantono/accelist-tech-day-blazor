using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorApp1.Entities
{
    /// <summary>
    /// This class allows running "dotnet-ef migrations add" command in the .Entities project
    /// whenever the table changes.
    /// </summary>
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
