using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TrueNetFinalProject.Models;

namespace TrueNetFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context context;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            context.Database.EnsureCreated();
            ViewBag.SearchCategory = new List<SelectListItem> {
            new SelectListItem { Value = "User", Text = "User" },
            new SelectListItem { Value = "Product", Text = "Product" }
};

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
