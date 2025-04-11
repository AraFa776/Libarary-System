using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstTry.Models;
namespace FirstTry.Controllers;
public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Search()
    {
        return View();
    }
}