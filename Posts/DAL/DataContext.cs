using Domain.Entity;
using Domain.Entity.Attach;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> optionts) : base(optionts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(f => f.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Attaches)
                .WithOne(a => a.Post)
                .HasForeignKey(f => f.PostId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("Posts"));
        }

        public DbSet<Post> Posts => Set<Post>();

        public DbSet<Comment> Comments => Set<Comment>();

        public DbSet<Attach> Attaches => Set<Attach>();
    }
}
