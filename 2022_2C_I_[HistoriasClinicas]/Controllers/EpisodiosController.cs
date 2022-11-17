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
    public class EpisodiosController : Controller
    {
        private readonly HistoriasClinicasContext _context;

        public EpisodiosController(HistoriasClinicasContext context)
        {
            _context = context;
        }

        // GET: Episodios
        public async Task<IActionResult> Index(int id )
        {
            return View(await _context.Episodios.ToListAsync());
        }

        // GET: Episodios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .FirstOrDefaultAsync(m => m.EpisodioId == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // GET: Episodios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Episodios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("EpisodioId,Motivo,Descripcion,DescripcionAtencion")] Episodio episodio)
        { if (id == null) { return Redirect("Home/Error"); }
            List<Nota> notas = new List<Nota>();
            episodio.Notas = notas;
            HistoriaClinica hc = _context.HistoriaClinica
                .FirstOrDefault(m => m.HistoriaClinicaId == id);
            episodio.HistoriaClinicaId = hc.HistoriaClinicaId;
            if (hc == null) { return Redirect("Home/Error"); }


            if (ModelState.IsValid)
            {
                _context.Add(episodio);
                await _context.SaveChangesAsync();
                return Redirect("/Episodios/MisEpisodios/" + id );
            }  
            return View(episodio);
        }

        // GET: Episodios/Edit/5
        public IActionResult CerrarEpisodio(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio =  _context.Episodios.Find(id);
            if (episodio == null)
            {
                return NotFound();
            }
            return View(episodio);
        }

        // POST: Episodios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CerrarEpisodio(int id)
        {
             Episodio? episodio = _context.Episodios.Find(id);
            if (episodio != null)
            {
                if (episodio.EstadoAbierto == true)
                {
                    try
                    {
                        episodio.EstadoAbierto = false;
                        episodio.FechaYHoraCierre = DateTime.Now;
                        _context.Update(episodio);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EpisodioExists(episodio.EpisodioId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return Redirect("/Episodios/MisEpisodios/" + episodio.HistoriaClinicaId);
                } 
                return Redirect("/Episodios/MisEpisodios/" + episodio.HistoriaClinicaId);
            }
            else { return NotFound(); }
        }

        // GET: Episodios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .FirstOrDefaultAsync(m => m.EpisodioId == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // POST: Episodios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Episodios == null)
            {
                return Problem("Entity set 'HistoriasClinicasContext.Episodios'  is null.");
            }
            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio != null)
            {
                _context.Episodios.Remove(episodio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult MisEpisodios(int id)
        {
            return View( _context.Episodios.Where(a => a.HistoriaClinicaId == id).ToList());
        }

        private bool EpisodioExists(int id)
        {
          return _context.Episodios.Any(e => e.EpisodioId == id);
        }

    }
}
