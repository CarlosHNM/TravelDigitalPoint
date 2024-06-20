using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelDigiatlPoint.Context;
using TravelDigiatlPoint.Models;

namespace TravelDigiatlPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRotaController : Controller
    {
        private readonly AppDbContext _context;

        public AdminRotaController(AppDbContext context)
        {
            _context = context;
        }

        // Get Admin/Admin
        public async Task<IActionResult> IndexAsync()
        {
            var rotas = _context.Rotas.Include(f => f.Funcionario).Include(v => v.Veiculo);
            return View(await rotas.ToListAsync());
        }

        // GET: Admin/AdminRotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rotas
                .Include(f => f.Funcionario)
                .Include(v => v.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rota == null)
            {
                return NotFound();
            }

            return View(rota);
        }

        // GET: Admin/AdminRotas/Create
        public IActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(_context.Funcionarios, "Id", "Nome");
            ViewBag.VeiculoId = new SelectList(_context.Veiculos, "Id", "Modelo");
            return View();
        }

        // POST: Admin/AdminRotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Origem,Destino,VeiculoId,FuncionarioId,FlDanos,DataHoraPartida,DataHoraChegada,ObservacaoMotorista")] Rota rota)
        {
            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
                _context.Add(rota);
                await _context.SaveChangesAsync();
            ViewBag.FuncionarioId = new SelectList(_context.Funcionarios, "Id", "Nome", rota.FuncionarioId);
            ViewBag.VeiculoId = new SelectList(_context.Veiculos, "Id", "Modelo", rota.VeiculoId);
            //return View(rota);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/AdminRotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rotas.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }

            ViewBag.FuncionarioId = new SelectList(_context.Funcionarios, "Id", "Nome", rota.FuncionarioId);
            ViewBag.VeiculoId = new SelectList(_context.Veiculos, "Id", "Modelo", rota.VeiculoId);
            return View(rota);
        }

        // POST: Admin/AdminRotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origem,Destino,VeiculoId,FuncionarioId,FlDanos,DataHoraPartida,DataHoraChegada,ObservacaoMotorista")] Rota rota)
        {
            if (id != rota.Id)
            {
                return NotFound();
            }

            //if (!ModelState.IsValid)
            //{
                try
                {
                    _context.Update(rota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotaExists(rota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            //    return RedirectToAction(nameof(Index));
            //}
            ViewBag.FuncionarioId = new SelectList(_context.Funcionarios, "Id", "Nome", rota.FuncionarioId);
            ViewBag.VeiculoId = new SelectList(_context.Veiculos, "Id", "Modelo", rota.VeiculoId);
            //return View(rota);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/AdminRotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rotas
                .Include(f => f.Funcionario)
                .Include(v => v.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rota == null)
            {
                return NotFound();
            }

            return View(rota);
        }

        // POST: Admin/AdminRotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            _context.Rotas.Remove(rota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotaExists(int id)
        {
            return _context.Rotas.Any(e => e.Id == id);
        }
    }
}
