
using Microsoft.EntityFrameworkCore;

namespace PMGateway.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Exemple de DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
