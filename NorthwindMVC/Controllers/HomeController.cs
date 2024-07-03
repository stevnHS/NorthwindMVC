using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Models;
using System.Diagnostics;

namespace NorthwindMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;

        public HomeController( NorthwindContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var customer = _context.Products.FirstOrDefault(c => c.ProductId == 5);

            if (customer == null)
            {
                return NotFound();
            }
            
            Console.WriteLine(customer?.ProductName);

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
