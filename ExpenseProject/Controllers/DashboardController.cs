using ExpenseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;
            List<Transaction> SelectedTransactions = await _context.Transaction
                .Include(x => x.cate).Where(y => y.Date >= StartDate && y.Date <= EndDate).ToListAsync();


            //income is gathered here 
            int TotalIncome = SelectedTransactions
                .Where(i => i.cate.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //expense is gathered here
            int TotalExpense = SelectedTransactions
            .Where(i => i.cate.Type == "Expense")
            .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //balance is gathered here

            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0");
            return View();
        }
    }
}
