using Microsoft.AspNetCore.Identity;
using MovieTickets.Data;
using MovieTickets.Data.Models;
using MovieTickets.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<MovieTicketsDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddApplicationDbContexts(builder.Configuration);
builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
options.SignIn.RequireConfirmedAccount = false)//true
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MovieTicketsDbContext>();

builder.Services.AddApplicationServices();

//builder.Services.AddScoped<IActorService, ActorService>();
//builder.Services.AddScoped<IProducerService, ProducerService>();
//builder.Services.AddScoped<IMovieService, MovieService>();
//builder.Services.AddScoped<ICinemaService, CinemaService>();
//builder.Services.AddScoped<IOrderService, OrderService>();

//builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
//builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//    //SeedData.SeedUsersAndRolesAsync(services).Wait();
//}

// Configure the HTTP request pipeline.

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
