using Microsoft.EntityFrameworkCore;
using MusicShop.Features.UseCases;
using MusicShop.Infrastructure.Database;
using MusicShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<MusicShopContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), sqlLiteOptions =>
    {
        sqlLiteOptions.MigrationsAssembly("MusicShop.Infrastructure");
    });
});

builder.Services.AddScoped<IMusicShopUseCase, MusicShopUseCase>();
builder.Services.AddScoped<IMusicShopRepository, MusicShopRepository>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5000"));
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
