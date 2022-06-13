using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Shared;

namespace ProductManagementApp.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
