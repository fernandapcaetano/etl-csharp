using System;
using Microsoft.EntityFrameworkCore;

namespace etl.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {

    }

    public DbSet<Models> Models { get; set;}
}
