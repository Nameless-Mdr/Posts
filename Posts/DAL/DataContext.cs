using Domain.Entity;
using Domain.Entity.Attach;
using Domain.Entity.User;
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
            modelBuilder.Entity<Avatar>().ToTable(nameof(Avatars));

            modelBuilder.Entity<Content>().ToTable(nameof(Contents));

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(f => f.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Contents)
                .WithOne(a => a.Post)
                .HasForeignKey(f => f.PostId);

            modelBuilder.Entity<User>()
                .HasIndex(f => f.Email)
                .IsUnique();

            modelBuilder.Entity<Like>()
                .HasIndex(f => new { f.AuthorId, f.PostId })
                .IsUnique();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("Posts"));
        }

        public DbSet<Post> Posts => Set<Post>();

        public DbSet<Comment> Comments => Set<Comment>();

        public DbSet<Attach> Attaches => Set<Attach>();

        public DbSet<User> Users => Set<User>();

        public DbSet<UserSession> UserSessions => Set<UserSession>();

        public DbSet<Avatar> Avatars => Set<Avatar>();

        public DbSet<Content> Contents => Set<Content>();

        public DbSet<Like> Likes => Set<Like>();
    }
}
