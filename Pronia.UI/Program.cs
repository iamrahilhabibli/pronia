using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;
using Pronia.DataAccess.Contexts;
using Pronia.UI.Services;
using Pronia.UI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IPersonService,PersonService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
{
	identityOptions.User.RequireUniqueEmail = true;
	identityOptions.Password.RequireNonAlphanumeric = true;
	identityOptions.Password.RequiredLength = 8;
	identityOptions.Password.RequireDigit = true;
	identityOptions.Password.RequireLowercase=true;
	identityOptions.Password.RequireUppercase=true;

	identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
	identityOptions.Lockout.MaxFailedAccessAttempts = 3;
	identityOptions.Lockout.AllowedForNewUsers = true;
})
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/ProniaAdmin/Auth/Login";
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
	name: "Default",
	pattern: "{controller=Home}/{action=Index}/{Id?}"
);
app.Run();
