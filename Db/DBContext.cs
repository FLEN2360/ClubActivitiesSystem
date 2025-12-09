using Microsoft.EntityFrameworkCore;

namespace ClubActivitiesSystem.Db
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Session> Sessions => Set<Session>();

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

            // Sessions
            modelBuilder.Entity<Session>()
                .HasIndex(x => x.UserId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasIndex(x => x.Token)
                .IsUnique();

            // Timestamps default (SQL Server)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.FindProperty("CreatedAt") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETDATE()");
                }

                if (entityType.FindProperty("UpdatedAt") != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>("UpdatedAt")
                        .HasDefaultValueSql("GETDATE()");
                }
            }
        }

        // 自動更新 UpdatedAt
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var prop = entry.Properties.FirstOrDefault(p => p.Metadata.Name == "UpdatedAt");
                if (prop != null)
                {
                    prop.CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}
