using TravelDigiatlPoint.Models;

namespace TravelDigiatlPoint.Repositories.Interface
{
    public interface IRotasTrabalhoRepository
    {
        IEnumerable<Rota> Rotas { get; }
        Rota GetRotaForFuncionarioById(int id);
    }
}
