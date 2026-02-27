using Microsoft.EntityFrameworkCore;
using Mission08_Team0408.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext using SQLite
builder.Services.AddDbContext<Mission08Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Mission08Connection")));

// ✅ ADD THIS: register your repository (so controllers can request it)
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
