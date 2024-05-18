using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class stockInDetailsController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public stockInDetailsController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: stockInDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbcontext = _context.StockInDetails.Include(s => s.prod);
            return View(await applicationDbcontext.ToListAsync());
        }

        // GET: stockInDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockInDetails == null)
            {
                return NotFound();
            }

            var stockInDetail = await _context.StockInDetails
                .Include(s => s.prod)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockInDetail == null)
            {
                return NotFound();
            }

            return View(stockInDetail);
        }

        // GET: stockInDetails/Create
        public IActionResult Create()
        {
            ViewData["prodId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: stockInDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(/*[Bind("Id,quantitySold,price,prodId")] */ stockInDetail stockInDetail)
        public async Task<IActionResult> Create(stockInDetail stockInDetail)

        {
            if (ModelState.IsValid)
            {
                var porduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == stockInDetail.prodId);
                if(porduct != null)
                {
                    if (porduct.QuantityInStock < stockInDetail.quantitySold)
                        return BadRequest();
                    else
                    {
                        porduct.QuantityInStock -= stockInDetail.quantitySold;
                    }



                }
                _context.Add(stockInDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["prodId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockInDetail.prodId);
            return View(stockInDetail);
        }

        // GET: stockInDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockInDetails == null)
            {
                return NotFound();
            }

            var stockInDetail = await _context.StockInDetails.FindAsync(id);
            if (stockInDetail == null)
            {
                return NotFound();
            }
            ViewData["prodId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockInDetail.prodId);
            return View(stockInDetail);
        }

        // POST: stockInDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantitySold,price,prodId")] stockInDetail stockInDetail)
        {
            if (id != stockInDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockInDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!stockInDetailExists(stockInDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["prodId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockInDetail.prodId);
            return View(stockInDetail);
        }

        // GET: stockInDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockInDetails == null)
            {
                return NotFound();
            }

            var stockInDetail = await _context.StockInDetails
                .Include(s => s.prod)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockInDetail == null)
            {
                return NotFound();
            }

            return View(stockInDetail);
        }

        // POST: stockInDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockInDetails == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.StockInDetails'  is null.");
            }
            var stockInDetail = await _context.StockInDetails.FindAsync(id);
            if (stockInDetail != null)
            {
                _context.StockInDetails.Remove(stockInDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool stockInDetailExists(int id)
        {
          return (_context.StockInDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
