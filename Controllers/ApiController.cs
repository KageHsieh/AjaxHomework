using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return Content("Hello World");
            //return Content("<h2>Hello World!!</h2>", "text/html");
        }

        public IActionResult AjaxEvent(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Guest";
            }
            System.Threading.Thread.Sleep(5000);
            return Content("Hello " + name);
        }

        public IActionResult Cities()
        {
            var cities = _context.Addresses.Select(c => c.City).Distinct();

            return Json(cities);
        }


        public IActionResult Districts(string city)
        {
            var districts = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string district)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == district).Select(a => a.Road).Distinct();

            return Json(roads);
        }

        public IActionResult CheckAccount(string email)
        {
            var checkAccount = _context.Members.FirstOrDefault(x => x.Email == email);

            return Json(checkAccount);
        }
    }
}
