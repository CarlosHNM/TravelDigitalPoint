using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDigiatlPoint.ViewModel;
using TravelDigiatlPoint.Context;
using TravelDigiatlPoint.Repositories.Interface;

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
            var Funcionario = new FuncionarioViewModel { };
            return View(Funcionario);
        }
    }
}
