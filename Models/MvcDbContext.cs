namespace MyMvcApp.Models;
using Microsoft.EntityFrameworkCore;

public class MvcDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options)
    {
        
    }
}