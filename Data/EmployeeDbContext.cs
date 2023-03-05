using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
        {

        }
        public DbSet<EmployementData> EmpData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(sc => new { sc.ActorId, sc.MovieId });
            
            modelBuilder.Entity<Actor_Movie>()
                .HasOne<Actor>(a => a.Actor)
                .WithMany(b => b.Actors_Movies)
                .HasForeignKey(a => a.ActorId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne<Movie>(s => s.Movie)
                .WithMany(s => s.Actors_Movies)
                .HasForeignKey(sc => sc.MovieId);
        }
    }
}
