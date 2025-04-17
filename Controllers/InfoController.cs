using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstTry.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult Aboutus()
        {
            return View();
        }
        public IActionResult PublisherPartnership()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }


       
    }
}
