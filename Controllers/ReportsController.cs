using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BookShoppingCartMvcUI.Controllers;
public class ReportsController : Controller
{
    private readonly IReportRepository _reportRepository;
    public ReportsController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }
    // GET: ReportsController
    public async Task<ActionResult> TopFiveSellingBooks(DateTime? sDate = null, DateTime? eDate = null)
    {
        try
        {
            // by default, get last 7 days record
            DateTime startDate = sDate ?? DateTime.UtcNow.AddDays(-7);
            DateTime endDate = eDate ?? DateTime.UtcNow;
            var topFiveSellingBooks = await _reportRepository.GetTopNSellingBooksByDate(startDate, endDate);
            var vm = new TopNSoldBooksVm(startDate, endDate, topFiveSellingBooks);
            return View(vm);
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = "Something went wrong";
            return RedirectToAction("Index", "Home");
        }
    }

    public async Task<IActionResult> ExportTopBooks(DateTime? startDate = null, DateTime? endDate = null)
    {
        DateTime start = startDate ?? DateTime.UtcNow.AddDays(-7);
        DateTime end = endDate ?? DateTime.UtcNow;

        var topBooks = await _reportRepository.GetTopNSellingBooksByDate(start, end);

        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("Book Title,Author,Units Sold");

        foreach (var book in topBooks)
        {
            csvBuilder.AppendLine($"{book.BookName},{book.AuthorName},{book.TotalUnitSold}");
        }

        byte[] fileBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        string fileName = $"TopBooks_{start:yyyy-MM-dd}_to_{end:yyyy-MM-dd}.csv";

        return File(fileBytes, "text/csv", fileName);
    }
}