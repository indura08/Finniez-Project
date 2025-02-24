using FinniezProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinniezProject.Data.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly AppDBContext _context;

        public ExpensesService(AppDBContext context)
        {
            _context = context;
        }

        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expenses
                                .GroupBy(e => e.Category)
                                .Select(g => new
                                {
                                    Category = g.Key,
                                    Total = g.Sum(e => e.Amount)
                                });
            return data;
            //At this stage, data is just a query. It hasn’t fetched any data yet! If you call: var list = data.ToList();  Now, the database actually runs the query and returns a list of results.

        }
    }
}
