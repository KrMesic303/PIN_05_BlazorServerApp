using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        private DbSet<Employee> Employees { get; set; }
    }
}
