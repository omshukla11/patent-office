using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models;

public class GIFormContext : DbContext
{
    public GIFormContext(DbContextOptions<GIFormContext> options)
        : base(options)
    {
    }

    public DbSet<GIForm> GIForms { get; set; } = null!;
}

