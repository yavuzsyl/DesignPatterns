using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Strategy.Models
{
    public class AppIdentiyDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentiyDbContext(DbContextOptions<AppIdentiyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
