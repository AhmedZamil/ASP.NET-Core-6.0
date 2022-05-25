using Marielinas.ASP.NET6._0.Data;
using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;
using Marielinas.ASP.NET6._0.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add or register services here

ConfigurationManager _configuration = builder.Configuration;


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<StoreUser, IdentityRole>(cfg=> {
    cfg.User.RequireUniqueEmail= true;
}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddTransient<Seeder>();
var app = builder.Build();


//Create scope from Scope factory rather trying to call from the app.services.GetService

//var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//var scope = scopedFactory?.CreateScope();

//var seeder = scope?.ServiceProvider.GetService<Seeder>();

//seeder?.SeedAsync().Wait();

//var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
//var scope = scopeFactory?.CreateScope();
//var seeder = scope?.ServiceProvider.GetService<Seeder>();
//seeder?.Seed();


// Create Request Pipeline Here

if (app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();