
using Hotel.Identity.Configurations;
using Hotel.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Identity
{
    public class HotelIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelIdentityDbContext(DbContextOptions<HotelIdentityDbContext> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
