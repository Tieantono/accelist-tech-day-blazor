using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Entities
{

    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Employee> Employees { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employee");
        }
    }
}
