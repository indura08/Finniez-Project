using FinniezProject.Data;
using FinniezProject.Data.Services;
using FinniezProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinniezProject.Controllers
{
    public class ExpensesController : Controller
    {
        //private readonly AppDBContext _context;

        //public ExpensesController(AppDBContext context)
        //{
        //    _context = context;

        //} // its is not a good practice to have datatbase access inside the controller when the application is hosted live in production environment so we have to create services

        private readonly IExpensesService _expenseService;

        public ExpensesController(IExpensesService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<IActionResult> Index()
        {
            //in index method we need to get all of the expenses data from database

            var expenses = await _expenseService.GetAll();
            
            //me return ekn krnne adla controller ekt thiyna index.cshtml file eka retun wewnwa view ekk widiyt 
            // e index.cshtml file ekt input ekk widiyt api me controller ekn output krnwa me expenses list eka 
            return View(expenses);

        }

        //me method ekn krnne create.cshtml page ek return krnwa user ta aluth expense ekk create krnna
        public IActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Create2(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await  _expenseService.Add(expense);
                

                return RedirectToAction("Index");
            }

            return View(expense);
        }

        public IActionResult GetChart() 
        {
            var data = _expenseService.GetChartData();
            return Json(data);
        }
    }
}
