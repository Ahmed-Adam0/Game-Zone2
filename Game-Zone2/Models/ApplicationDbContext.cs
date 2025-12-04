using System;
using Microsoft.EntityFrameworkCore;

namespace Game_Zone2.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet <Game> games { get; set; }
        public DbSet <Category> categories { get; set; }
        public IEnumerable<object>? Categories { get; internal set; }
        public DbSet <Device> devices { get; set; }
        public DbSet <GameDevice> gameDevices { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                 {
                    new Category { ID = 1, Name = "Action" },
                    new Category { ID = 2, Name = "Adventure" },
                    new Category { ID = 3, Name = "RPG" },
                    new Category { ID = 4, Name = "Strategy" },
                    new Category { ID = 5, Name = "Simulation" }
                 }
             
                );
            modelBuilder.Entity<Device>()
                .HasData(new Device[] {
                    new Device { ID = 1, Name = "PC", Icon="pc-icon" },
                    new Device { ID = 2, Name = "PlayStation", Icon="playstation-icon" },
                    new Device { ID = 3, Name = "Xbox", Icon="xbox-icon" },
                    new Device { ID = 4, Name = "Nintendo Switch", Icon="nintendo-icon" }
                }); 
            modelBuilder.Entity<GameDevice>()
                .HasKey(g => new { g.GameId, g.DeviceId });
               
            base.OnModelCreating(modelBuilder);
        }
    }
}
