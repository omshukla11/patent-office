using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models;

public class OwnerContext : DbContext
{
    public OwnerContext(DbContextOptions<OwnerContext> options)
        : base(options)
    {
    }

    public DbSet<Owner> Owners { get; set; } = null!;
}
