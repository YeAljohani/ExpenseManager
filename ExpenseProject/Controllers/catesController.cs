using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseProject.Models;

namespace ExpenseProject.Controllers
{
    public class catesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public catesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cates
        public async Task<IActionResult> Index()
        {
            return View(await _context.cate.ToListAsync());
        }

        // GET: cates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.cate
                .FirstOrDefaultAsync(m => m.cateId == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // GET: cates/AddEdit
        public IActionResult AddEdit(int id = 0)
        {
            if (id == 0)
                return View(new cate());
            else
                return View(_context.cate.Find(id));

        }

        // POST: cates/AddEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("cateId,Title,Type,img")] cate cate)
        {
            if (ModelState.IsValid)
            {
                if (cate.cateId == 0)
                    _context.Add(cate);
                else
                    _context.Update(cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cate);
        }

      
        // GET: cates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.cate
                .FirstOrDefaultAsync(m => m.cateId == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // POST: cates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cate = await _context.cate.FindAsync(id);
            if (cate != null)
            {
                _context.cate.Remove(cate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cateExists(int id)
        {
            return _context.cate.Any(e => e.cateId == id);
        }
    }
}
