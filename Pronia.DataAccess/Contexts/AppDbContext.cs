using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;

namespace Pronia.DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Slider> Sliders { get; set; } = null!;
	public DbSet<Shipping> shippings { get; set; } = null!;
	public DbSet<Product> products { get; set; } = null!;
	public DbSet<Banners> Banners { get; set; } = null!;
	public DbSet<Users> Users { get; set; } = null!;
	public DbSet<SwiperSlider> SwiperSlider { get; set; } = null!;
	public DbSet<Blogs> Blogs { get; set; } = null!;
	public DbSet<NewProducts> NewProducts { get; set; } // wrong- should be same productss class!

}
