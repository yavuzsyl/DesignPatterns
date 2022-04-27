

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Decorator.Models
{
    public class AppIdentiyDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentiyDbContext(DbContextOptions<AppIdentiyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
