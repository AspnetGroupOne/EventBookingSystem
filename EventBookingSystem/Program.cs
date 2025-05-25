using EventBookingSystem.Contexts;
using EventBookingSystem.Repository;
using EventBookingSystem.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<EventRepository>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => { options.AddPolicy("AllowAll", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

builder.Services.AddHttpClient<BookingApiService>(client =>
{
    client.BaseAddress = new Uri("https://booking-api-service.azurewebsites.net/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});


builder.Services.AddScoped<BookingApiService>();
builder.Services.AddScoped<EventIntegrationService>();


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
