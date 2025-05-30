﻿using EventBookingSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Contexts;

public class DataContext(DbContextOptions<DataContext> options)
    : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
}
