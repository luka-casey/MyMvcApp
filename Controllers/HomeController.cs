using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MvcDbContext _context;

    public HomeController(ILogger<HomeController> logger, MvcDbContext context)
    {
        _logger = logger;
        _context = context;
    }

//Todo learn about file segmentation
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();
        
        var totalExpenses = allExpenses.Sum(e => e.Value);
        
        ViewBag.Expenses = totalExpenses;
        
        return View(allExpenses);
    }
    public IActionResult CreateEditExpense(int? Id)
    {
        if (Id != null)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == Id);
            return View(expense);
        }
        
        return View();
    }
    
    public IActionResult DeleteExpense(int Id)
    {
        var expense = _context.Expenses.SingleOrDefault(e => e.Id == Id);
        _context.Expenses.Remove(expense);
        _context.SaveChanges();
        
        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if (model.Id == 0)
        {
            _context.Expenses.Add(model);
        }
        else
        {
            _context.Expenses.Update(model);
        }
        
        _context.SaveChanges();
        
        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
