using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminplaner.Model.Enums;

namespace Terminplaner.Model.Entities
{
    /// <summary>
    /// represents the database context for the terminplaner app
    /// manages the database connection and providfes DbSets for entity access
    /// </summary>
    public class TerminplanerDbContext : DbContext
    {
        /// <summary>
        /// The DbContextOptions parameter allows dependency injection to configure the context
        /// </summary>
        public TerminplanerDbContext(DbContextOptions<TerminplanerDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// represents Appointment table
        /// </summary>
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// configures entity properties and relatoinships using modelBuilder
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userId1 = Guid.Parse("b2b76e15-fb17-4c90-bf60-5016b3c7c6df");
            var userId2 = Guid.Parse("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c");

            // way nr. 1 
            modelBuilder.Entity<User>()
                .Property(x => x.PasswordHash)
                .HasColumnName("Password");

            // alternative way
            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(user => user.Username).HasColumnType("varchar(200)");
                eb.Property(user => user.Email).HasColumnType("varchar(200)");
                eb.Property(user => user.Role).HasConversion<string>();
                eb.HasData
                (
                    new User() { Id = userId1, Username = "TestUser", PasswordHash = "test", Email = "test@test.com", Role = UserRole.Employee },
                    new User { Id = userId2, Username = "admin", PasswordHash = "admin", Email = "admin@admin.com", Role = UserRole.Administrator }
                );

                // one user to many appointments
                eb.HasMany(u => u.Appointments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
            });

            modelBuilder.Entity<Appointment>(ap =>
            {
                ap.Property(ap=> ap.Status).HasConversion<string>();
                ap.HasData
                (
                    new Appointment { Id = 1, Title = "Meeting", Description = "Scrum daily", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Status = AppointmentStatus.Scheduled, UserId = userId1 },
                    new Appointment { Id = 2, Title = "Code Review", Description = "Review code with team", StartTime = DateTime.Now.AddHours(2), EndTime = DateTime.Now.AddHours(3), Status = AppointmentStatus.Scheduled, UserId = userId2 }
                );
            });

        }
    }
}
