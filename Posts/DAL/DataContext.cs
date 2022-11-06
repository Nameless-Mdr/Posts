using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> optionts) : base(optionts)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("Posts"));
        }

        public DbSet<Post> Posts => Set<Post>();
    }
}
