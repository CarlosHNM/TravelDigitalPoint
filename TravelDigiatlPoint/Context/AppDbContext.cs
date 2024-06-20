using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelDigiatlPoint.Models;

namespace TravelDigiatlPoint.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<ManutencaoVeiculo> ManutencoesVeiculo { get; set; }
    }
}
