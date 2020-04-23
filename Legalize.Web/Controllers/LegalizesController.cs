using Legalize.Web.Data;
using Legalize.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exists a trip with the same id.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
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
                
                    _context.Update(legalizeEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already exists a trip with the same document.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
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

            _context.Legalizes.Remove(legalizeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
