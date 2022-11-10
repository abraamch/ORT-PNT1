using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2022_2C_I__HistoriasClinicas_.Data;

namespace _2022_2C_I__HistoriasClinicas_.Controllers
{
    public class HistoriaClinicasController : Controller
    {
        private readonly HistoriasClinicasContext _context;

        public HistoriaClinicasController(HistoriasClinicasContext context)
        {
            _context = context;
        }

        // GET: HistoriaClinicas
        public async Task<IActionResult> Index()
        {
            var historiasClinicasContext = _context.HistoriaClinica.Include(h => h.Paciente);
            return View(await historiasClinicasContext.ToListAsync());
        }

        // GET: HistoriaClinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistoriaClinicaId == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "apellido");
            return View();
        }

        // POST: HistoriaClinicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoriaClinicaId,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaClinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica.FindAsync(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoriaClinicaId,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (id != historiaClinica.HistoriaClinicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaClinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaClinicaExists(historiaClinica.HistoriaClinicaId))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistoriaClinicaId == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoriaClinica == null)
            {
                return Problem("Entity set 'HistoriasClinicasContext.HistoriaClinica'  is null.");
            }
            var historiaClinica = await _context.HistoriaClinica.FindAsync(id);
            if (historiaClinica != null)
            {
                _context.HistoriaClinica.Remove(historiaClinica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaClinicaExists(int id)
        {
          return _context.HistoriaClinica.Any(e => e.HistoriaClinicaId == id);
        }
    }
}
