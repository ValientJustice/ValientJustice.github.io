using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueNetFinalProject.Models;

namespace TrueNetFinalProject.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly Context _context;

        public OrderItemController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            IQueryable<OrderItem> query = _context.OrderItems;

            if (id.HasValue)
            {
                query = query.Where(o => o.orderId == id);
            }
            var orderItems = await query.ToListAsync();

            return View(orderItems);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.OrderItems
                .FirstOrDefaultAsync(u => u.orderItemId == id);

            return View(order);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderItemId,orderId,productId,quantity")] OrderItem orderItem)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(orderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            return View(orderItem);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderItemId,orderId,productId,quantity")] OrderItem orderItem)
        {
            if (id != orderItem.orderItemId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(orderItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(orderItem.orderItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            return View(orderItem);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems
                .FirstOrDefaultAsync(m => m.orderItemId == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.OrderItems.Any(e => e.orderId == id);
        }
    }
}
