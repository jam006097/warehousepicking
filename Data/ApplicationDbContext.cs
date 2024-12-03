using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PickingRoute.Models;

namespace PickingRoute.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	public DbSet<ProductItem> ProductItems { get; set; }
	public DbSet<Shelf> Shelves { get; set; }
	public DbSet<WarehousePath> Paths { get; set; }


}
