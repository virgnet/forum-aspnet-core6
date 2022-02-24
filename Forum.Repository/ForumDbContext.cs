using Microsoft.EntityFrameworkCore;
using Forum.Domain;

namespace Forum.Repository
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
        {

        }
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=forum-db;User=sa;Password=***";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<User> User { get; set; }
        public DbSet<Topic> Topic { get; set; }
    }
}
