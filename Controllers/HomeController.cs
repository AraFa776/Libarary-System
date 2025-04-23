using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstTry.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstTry.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookhupContext _context;
    public HomeController(ILogger<HomeController> logger, BookhupContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.Books
              .Include(b => b.Author)
              .Include(b => b.Publisher)
              .ToList();
        return View(books);
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
