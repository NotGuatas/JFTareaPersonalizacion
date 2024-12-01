using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JFTareaPersonalizacion.Data;
using JFTareaPersonalizacion.Models;

namespace JFTareaPersonalizacion.Controllers
{
    public class JFsuplementosController : Controller
    {
        private readonly JFTareaPersonalizacionContext _context;

        public JFsuplementosController(JFTareaPersonalizacionContext context)
        {
            _context = context;
        }

        // GET: JFsuplementos
        public async Task<IActionResult> JFIndex()
        {
            return View(await _context.JFsuplementos.ToListAsync());
        }

        // GET: JFsuplementos/Details/5
        public async Task<IActionResult> JFDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jFsuplementos = await _context.JFsuplementos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jFsuplementos == null)
            {
                return NotFound();
            }

            return View(jFsuplementos);
        }

        // GET: JFsuplementos/Create
        public IActionResult JFCreate()
        {
            return View();
        }

        // POST: JFsuplementos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JFCreate([Bind("ID,Nombre,Whey,Cafeina,Precio")] JFsuplementos jFsuplementos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jFsuplementos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(JFIndex));
            }
            return View(jFsuplementos);
        }

        // GET: JFsuplementos/Edit/5
        public async Task<IActionResult> JFEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jFsuplementos = await _context.JFsuplementos.FindAsync(id);
            if (jFsuplementos == null)
            {
                return NotFound();
            }
            return View(jFsuplementos);
        }

        // POST: JFsuplementos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JFEdit(int id, [Bind("ID,Nombre,Whey,Cafeina,Precio")] JFsuplementos jFsuplementos)
        {
            if (id != jFsuplementos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jFsuplementos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JFsuplementosExists(jFsuplementos.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(JFIndex));
            }
            return View(jFsuplementos);
        }

        // GET: JFsuplementos/Delete/5
        public async Task<IActionResult> JFDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jFsuplementos = await _context.JFsuplementos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jFsuplementos == null)
            {
                return NotFound();
            }

            return View(jFsuplementos);
        }

        // POST: JFsuplementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JFDeleteConfirmed(int id)
        {
            var jFsuplementos = await _context.JFsuplementos.FindAsync(id);
            if (jFsuplementos != null)
            {
                _context.JFsuplementos.Remove(jFsuplementos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JFIndex));
        }

        private bool JFsuplementosExists(int id)
        {
            return _context.JFsuplementos.Any(e => e.ID == id);
        }
    }
}
