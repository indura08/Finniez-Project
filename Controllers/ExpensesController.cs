using FinniezProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinniezProject.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDBContext _context;

        public ExpensesController(AppDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            //in index method we need to get all of the expenses data from database

            var expenses = _context.Expenses.ToList();
            
            //me return ekn krnne adla controller ekt thiyna index.cshtml file eka retun wewnwa view ekk widiyt 
            // e index.cshtml file ekt input ekk widiyt api me controller ekn output krnwa me expenses list eka 
            return View(expenses);

        }

        //me method ekn krnne create.cshtml page ek return krnwa user ta aluth expense ekk create krnna
        public IActionResult Create()
        {
            return View();
            //37:42 n nwattuwe
        }
    }
}
