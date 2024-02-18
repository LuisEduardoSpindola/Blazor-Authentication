using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraestructureLayer.Areas.Data
{
    public class AdvContext : IdentityDbContext<User>
    {
        public AdvContext(DbContextOptions<AdvContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> users { get; set; }
    }
}
