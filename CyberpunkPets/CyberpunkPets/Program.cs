using CyberpunkPets.Data;
using CyberpunkPets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));
builder.Services.AddDbContext<AuthenticationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();

var app = builder.Build();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    var adb = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    adb.Database.EnsureDeleted();
    adb.Database.EnsureCreated();
}
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("Default", "{Controller=Animal}/{action=Index}/{Id?}");
app.Run();
