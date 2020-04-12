using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Controllers
{
    public class LegalizesController : Controller
    {
        private readonly DataContext _context;

        public LegalizesController(DataContext context)
        {
            _context = context;
        }

        // GET: Legalizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Legalizes.ToListAsync());
        }

        // GET: Legalizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return View(legalizeEntity);
        }

        // GET: Legalizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Legalizes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LegalizeEntity legalizeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legalizeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legalizeEntity);
        }

        // GET: Legalizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes.FindAsync(id);
            if (legalizeEntity == null)
            {
                return NotFound();
            }
            return View(legalizeEntity);
        }

        // POST: Legalizes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LegalizeEntity legalizeEntity)
        {
            if (id != legalizeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legalizeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegalizeEntityExists(legalizeEntity.Id))
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
            return View(legalizeEntity);
        }

        // GET: Legalizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalizeEntity legalizeEntity = await _context.Legalizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legalizeEntity == null)
            {
                return NotFound();
            }

            return View(legalizeEntity);
        }

        // POST: Legalizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            LegalizeEntity legalizeEntity = await _context.Legalizes.FindAsync(id);
            _context.Legalizes.Remove(legalizeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegalizeEntityExists(int id)
        {
            return _context.Legalizes.Any(e => e.Id == id);
        }
    }
}
