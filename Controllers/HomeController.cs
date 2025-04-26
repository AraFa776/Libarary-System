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
        // الكتب الأكثر طلباً (حسب عدد الطلبات في OrderDetails)
        var trendingBooks = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category) // تأكد من تضمين الفئة
            .OrderByDescending(b => b.OrderDetails.Sum(od => od.Quantity))
            .Take(6)
            .ToList();

        ViewBag.TrendingBooks = trendingBooks;
        ViewBag.Categories = _context.Categories.ToList();

        // الكتب العادية للصفحة الرئيسية
        var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Where(b => b.Author != null)
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
