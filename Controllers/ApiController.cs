using Microsoft.AspNetCore.Mvc;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Hello World");
            return Content("<h2>Hello World!!</h2>", "text/html");
        }
    }
}
