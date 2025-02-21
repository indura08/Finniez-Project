using FinniezProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinniezProject.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        DbSet<Expense> Expenses { get; set; }

        
    }
}
