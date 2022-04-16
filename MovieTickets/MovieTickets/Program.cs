using Microsoft.AspNetCore.Identity;
using MovieTickets.Data;
using MovieTickets.Data.Models;
using MovieTickets.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationDbContexts(builder.Configuration);
builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
options.SignIn.RequireConfirmedAccount = false)//true
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MovieTicketsDbContext>();

builder.Services.AddApplicationServices();


builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//Old way for seeding which was not working very good, but still seeded
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//    //SeedData.SeedUsersAndRolesAsync(services).Wait();
//}

// Configure the HTTP request pipeline.

//New way of seeding
//app.PrepareDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
