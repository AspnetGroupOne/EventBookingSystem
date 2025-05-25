using EventBookingSystem.Contexts;
using EventBookingSystem.Repository;
using EventBookingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<EventRepository>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => { options.AddPolicy("AllowAll", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles(); 

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
