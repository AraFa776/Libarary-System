using BookShoppingCartMvcUI.Models;
using BookShoppingCartMvcUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Diagnostics;

namespace BookShoppingCartMvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository, ApplicationDbContext context)
        {
            _logger = logger;
            _homeRepository = homeRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            IndexVm result = new IndexVm();

            result.Categories = _context.Genres.ToList();
            result.Books = _context.Books.Include(b => b.Stock).ToList();
            result.Reviews = _context.Review.ToList();


            foreach (var book in result.Books)
            {
                if (book.Stock != null) 
                {
                    book.Quantity = book.Stock.Quantity;
                }
            }

            return View(result);
        }

        public IActionResult Category()
        {
            var data = _context.Genres.ToList();
            ViewBag.Books = _context.Books.ToList();
            return View(data);
        }
        public IActionResult Book(int id)
        {
            var data = _context.Books
                .Include(b => b.Stock)
                .Include(b => b.Genre)
                .Where(x => x.GenreId == id)
                .ToList();

            foreach (var book in data)
            {
                if (book.Stock != null)
                {
                    book.Quantity = book.Stock.Quantity;
                }
            }

            return View(data);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Review()
        {
            IndexVm result = new IndexVm();
            result.Reviews = _context.Review.ToList();
            return View(result);
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult BookSearch(string xname)
        {
            var data = new List<Book>();

            if (string.IsNullOrEmpty(xname))
            {
                data = _context.Books
                    .Include(b => b.Stock)
                    .Include(b => b.Genre)
                    .ToList();
            }
            else
            {
                data = _context.Books
                    .Include(b => b.Stock)
                    .Include(b => b.Genre)
                    .Where(b => b.BookName.Contains(xname))
                    .ToList();
            }

            foreach (var book in data)
            {
                if (book.Stock != null) 
                {
                    book.Quantity = book.Stock.Quantity;
                }
            }

            return View(data);
        }

        public IActionResult SendReview(ReviewVM model)
        {
            _context.Review.Add(new Review { Name = model.Name, Email = model.Email, Subject = model.Subject, Description = model.Description });
            _context.SaveChanges();
            return RedirectToAction("Review");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}