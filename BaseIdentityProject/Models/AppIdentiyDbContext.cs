

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentityProject.Models
{
    public class AppIdentiyDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentiyDbContext(DbContextOptions<AppIdentiyDbContext> options) : base(options)
        {

        }
    }
}
