using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueNetFinalProject.Models;

namespace TrueNetFinalProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly Context _context;

        public SearchController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? category, string? searchString)
        {
            // Pass the category back to the View so you can use it elsewhere on the page
            ViewData["SelectedCategory"] = category ?? "Users";

            // 1. Determine which table to query
            if (category == "Order")
            {
                var query = _context.Orders.AsQueryable();
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(o => o.destination.Contains(searchString)); 

                return View("OrderResults", await query.ToListAsync());
            }
            else if (category == "Product")
            {
                var query = _context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(p => p.productName.Contains(searchString) || p.location.Contains(searchString)); 

                return View("ProductResults", await query.ToListAsync());
            }
            else // Default to Users
            {
                var query = _context.Users.AsQueryable();
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(u => u.FName.Contains(searchString) || u.LName.Contains(searchString)); 

                return View("UserResults", await query.ToListAsync());
            }
        }

    }
}
