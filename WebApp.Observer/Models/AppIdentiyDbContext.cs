

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Observer.Models;

namespace WebApp.Observer.Models;
public class AppIdentiyDbContext : IdentityDbContext<AppUser>
{
    public AppIdentiyDbContext(DbContextOptions<AppIdentiyDbContext> options) : base(options)
    {

    }

    public DbSet<Discount> Discounts { get; set; }
}
