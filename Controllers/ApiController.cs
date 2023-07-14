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

        public IActionResult Cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();

            return Json(cities);
        }

        public IActionResult Districts(string city) 
        { 
            var districts = _context.Address.Where(a=>a.City == city).Select(a=>a.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string district)
        {
            var roads = _context.Address.Where(a => a.SiteId == district).Select(a => a.Road).Distinct();

            return Json(roads);
        }
    }
}
