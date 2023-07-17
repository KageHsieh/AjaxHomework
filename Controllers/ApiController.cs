using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
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

        [HttpPost]

        public IActionResult Register(Member member, IFormFile Photo)
        {
            //string photoinfo = $"{Photo.FileName} - {Photo.Length} - {Photo.ContentType}";
            string rootPath = Path.Combine(_host.WebRootPath, "uploads", Photo.FileName);
            using(var fileStream = new FileStream(rootPath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }

            //寫進資料庫
            member.FileName = Photo.FileName;
            byte[]? photoByte = null;
            using (var memoryStream =  new MemoryStream())
            {
                Photo.CopyTo(memoryStream);
                photoByte = memoryStream.ToArray();
            }
                member.FileData = photoByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            return Content(rootPath);
        }

        public IActionResult GetImageByte(int id=0) 
        {
            Member? _member = _context.Members.Find(id);
            byte[]? img = _member.FileData;
            return File( img, "image/jpeg");
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
