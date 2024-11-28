using ElevatorChallengAPI.Domain;
using ElevatorChallengAPI.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ElevatorChallengAPI.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Elevator> Elevators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasKey(b => b.Id);
            modelBuilder.Entity<Building>().HasData(
                new Building { Id = Guid.NewGuid(), Name = "Building 1", Address = "123 Main St", Status = Status.Active, Elevators = [] });
            modelBuilder.Entity<Elevator>().HasKey(e => e.Id);
            modelBuilder.Entity<Elevator>().HasData(
                new Elevator { Id = Guid.NewGuid(), BuildingId = Guid.NewGuid(), Name = "Elevator 1", CurrentFloor = Floor.Ground, Status = Status.Active, ElevatorStatus = ElevatorStatus.Working });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("elevatordb");
        }
    }
}
