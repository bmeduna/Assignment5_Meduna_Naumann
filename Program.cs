using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment5_Meduna_Naumann.Data;
using Assignment5_Meduna_Naumann.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Assignment5_Meduna_NaumannContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment5_Meduna_NaumannContext") ?? throw new InvalidOperationException("Connection string 'Assignment5_Meduna_NaumannContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Assignment5_Meduna_NaumannContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
