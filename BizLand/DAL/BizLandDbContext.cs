using BizLand.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BizLand.DAL
{
    public class BizLandDbContext:IdentityDbContext<AppUser>
    {
        public BizLandDbContext(DbContextOptions<BizLandDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FeaturedService> FeaturedServices { get; set; }
    }
}
