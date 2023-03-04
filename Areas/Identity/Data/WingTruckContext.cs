using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WingTruck.Areas.Identity.Data;
using WingTruck.Models;

namespace WingTruck.Data;

public class WingTruckContext : IdentityDbContext<WingTruckUser>
{
    public WingTruckContext(DbContextOptions<WingTruckContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<WingTruck.Models.Order> Order { get; set; }

    public DbSet<WingTruck.Models.Executive> Executive { get; set; }

    public DbSet<WingTruck.Models.Customer> Customer { get; set; }
}
