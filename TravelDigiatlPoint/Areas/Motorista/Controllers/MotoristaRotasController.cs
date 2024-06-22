using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDigiatlPoint.Context;
using TravelDigiatlPoint.Models;
using TravelDigiatlPoint.Repositories.Interface;
using TravelDigiatlPoint.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDigiatlPoint.Areas.Motorista.Controllers
{
    [Area("Motorista")]
    public class MotoristaRotasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IRotasTrabalhoRepository _rotasTrabalhoRepository;

        public MotoristaRotasController(AppDbContext context, IRotasTrabalhoRepository rotasTrabalhoRepository)
        {
            _context = context;
            _rotasTrabalhoRepository = rotasTrabalhoRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new FuncionarioViewModel
            {
                Funcionarios = _context.Funcionarios.Where(x => x.Cargo == Cargo.Motorista).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var rotas = _rotasTrabalhoRepository.Rotas
                .Where(r => r.FuncionarioId == id)
                .ToList();

            if (!rotas.Any())
            {
                return NotFound();
            }

            return View(rotas);
        }

        // GET: MotoristaRotas/StartTrip/5
        public async Task<IActionResult> StartTrip(int id)
        {
            var rota = await _context.Rotas
                .Include(r => r.Veiculo)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rota == null)
            {
                return NotFound();
            }

            rota.DataHoraPartida = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Rotas.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction("Details", new { id = rota.FuncionarioId });
        }


        // GET: MotoristaRota/EndTrip/5
        public async Task<IActionResult> EndTrip(int id)
        {
            var rota = await _context.Rotas
                .Include(r => r.Veiculo)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rota == null)
            {
                return NotFound();
            }

            return View(rota);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EndTrip(int id, [Bind("Id,DataHoraChegada,FlDanos,ObservacaoMotorista")] Rota rotaUpdate)
        {
            var rota = await _context.Rotas
                .Include(r => r.Veiculo)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rota == null)
            {
                return NotFound();
            }

            rota.DataHoraChegada = DateTime.Now;
            rota.FlDanos = rotaUpdate.FlDanos;
            rota.ObservacaoMotorista = rotaUpdate.ObservacaoMotorista;

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(rota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Rotas.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = rota.FuncionarioId });
            //}

            //return View(rota);
        }
    }
}
