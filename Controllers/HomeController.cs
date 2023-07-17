using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Msit147Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Address() 
        {
            return View();
        }

        public IActionResult CheckAccount()
        {
            return View();
        }

        public IActionResult HomeWork1()
        {
            return View();
        }


        public IActionResult HomeWork2()
        {
            return View();
        }

        public IActionResult HomeWork3()
        {
            return View();
        }

        public IActionResult HomeWork4()
        {
            return View();
        }

        public IActionResult HomeWork5()
        {
            return View();
        }

        public IActionResult HomeWork6()
        {
            return View();
        }

        public IActionResult Fetch() 
        {
            return View();
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
}