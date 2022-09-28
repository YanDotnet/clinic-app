using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Days;
using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.Schedules;
using ScheduleService.Domain.ValueObjects;

namespace ScheduleService.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Day> Days { get; set; }

    public DbSet<Registration> Registrations { get; set; }

    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Day>()
        //     .Property(x => x.AvailableTime)
        //     .HasConversion(
        //         x => new { x.Start, x.End },
        //         x => new TimeRange(x.Start, x.End))
        //     .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        //
        // modelBuilder.Entity<Registration>()
        //     .Property(x => x.Time)
        //     .HasConversion(
        //         x => new { x.Start, x.End },
        //         x => new TimeRange(x.Start, x.End))
        //     .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        modelBuilder.Entity<Day>()
            .OwnsOne(d => d.AvailableTime);

        modelBuilder.Entity<Registration>()
            .OwnsOne(d => d.Time);
    }
}