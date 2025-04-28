using EventBookingSystem.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Contexts;

public class DataContext(DbContextOptions<DataContext> options)
    : IdentityDbContext<>(options)
{
    public DbSet<EventEntity> Events { get; set; }

}