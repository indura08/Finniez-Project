using FinniezProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinniezProject.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        
    }
}
