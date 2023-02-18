using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models;

public class GIFormContext : DbContext
{
    public GIFormContext(DbContextOptions<GIFormContext> options)
        : base(options)
    {
    }

    public DbSet<GIForm> GIForms { get; set; } = null!;
    public DbSet<Owner> Owners { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GIForm>()
            .HasOne(p => p.Owner)
            .WithMany(p => p.GIForms)
            .HasForeignKey(p => p.OwnerId);
    }
}

