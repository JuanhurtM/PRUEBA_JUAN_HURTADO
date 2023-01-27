using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRUEBA_JUAN_HURTADO.Models;

namespace PRUEBA_JUAN_HURTADO.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ResultadosContext _context;

        public ResultadoController(ResultadosContext context)
        {
            _context = context;
        }

        // GET: Resultado
        public async Task<IActionResult> Index()
        {
              return View(await _context.Resultados.ToListAsync());
        }

        // GET: Resultado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resultados == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resultado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,Arranque,Envio")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultado);
        }

        // GET: Resultado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resultados == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }

        // POST: Resultado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,Arranque,Envio")] Resultado resultado)
        {
            if (id != resultado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.Id))
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
            return View(resultado);
        }

        // GET: Resultado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resultados == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resultados == null)
            {
                return Problem("Entity set 'ResultadosContext.Resultados'  is null.");
            }
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
          return _context.Resultados.Any(e => e.Id == id);
        }
    }
}
