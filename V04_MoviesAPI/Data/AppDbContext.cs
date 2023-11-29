using Microsoft.EntityFrameworkCore;

namespace V04_MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
    }

}
