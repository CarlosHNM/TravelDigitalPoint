using Microsoft.EntityFrameworkCore;
using TravelDigiatlPoint.Context;
using TravelDigiatlPoint.Models;
using TravelDigiatlPoint.Repositories.Interface;

namespace TravelDigiatlPoint.Repositories
{
    public class RotasRepository : IRotasTrabalhoRepository
    {
        private readonly AppDbContext _context;

        public RotasRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rota> Rotas => _context.Rotas.Include(c => c.Funcionario).Include(c => c.Veiculo);

        public Rota GetRotaForFuncionarioById(int funcionarioId)
        {
            return _context.Rotas.FirstOrDefault(l => l.Funcionario.Id == funcionarioId);
        }
    }
}
