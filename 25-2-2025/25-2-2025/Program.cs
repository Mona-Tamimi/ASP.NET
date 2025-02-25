using Microsoft.EntityFrameworkCore;
using _25_2_2025.Models;

var builder = WebApplication.CreateBuilder(args);

// ? Add Distributed Cache & Session Services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ? Register IHttpContextAccessor for Session Access
builder.Services.AddHttpContextAccessor();

// ? Add Database Context with Exception Handling
builder.Services.AddDbContext<MyDbContext>(options =>
{
    try
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection error: {ex.Message}");
    }
});

// ? Add MVC Services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ? Configure Middleware Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // ?? Moved up before `UseSession()`
app.UseSession(); // ? Ensure Session Middleware is applied after Routing

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

