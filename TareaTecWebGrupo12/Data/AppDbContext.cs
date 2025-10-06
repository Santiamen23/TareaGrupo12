
using System;
using Microsoft.EntityFrameworkCore;
using TareaTecWebGrupo12.Models;

namespace TareaTecWebGrupo12.Data

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Ticket> tickets => Set<Ticket>();
    public DbSet<Guest> Guest => Set<Guest>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Event>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).IsRequired().HasMaxLength(200);
            e.Property(x => x.Date).IsRequired();
            e.Property(x => x.Capacity).IsRequired();
        });
        modelBuilder.Entity<Ticket>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Notes).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Guest>(g =>
        {
            g.HasKey(x => x.Id);
            g.Property(x => x.FullName).IsRequired().HasMaxLength(200);
            g.HasKey(x => x.Confirmed);
        });
    }

    } 
}
