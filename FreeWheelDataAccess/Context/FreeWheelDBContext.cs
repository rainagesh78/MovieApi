using FreeWheelDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreeWheelDataAccess.Context
{
    public class FreeWheelDBContext : DbContext
    {
        public FreeWheelDBContext(DbContextOptions<FreeWheelDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rating>()
                .HasKey(m => new { m.MovieId, m.UserId });

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
       

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}
