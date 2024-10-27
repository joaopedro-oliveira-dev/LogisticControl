using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Core;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}