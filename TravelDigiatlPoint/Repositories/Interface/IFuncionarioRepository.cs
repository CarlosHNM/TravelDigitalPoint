using TravelDigiatlPoint.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelDigiatlPoint.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> GetFuncionarioById(int id);
        Task AddFuncionario(Funcionario funcionario);
        Task UpdateFuncionario(Funcionario funcionario);
        Task DeleteFuncionario(int id);
    }
}
