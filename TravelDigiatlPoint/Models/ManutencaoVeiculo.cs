using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelDigiatlPoint.Models
{
    public class ManutencaoVeiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

        [Required]
        [Display(Name = "Motorista")]
        public int MotoristaId { get; set; }

        [ForeignKey("MotoristaId")]
        public Funcionario Motorista { get; set; }

        [Required]
        [Display(Name = "Mecânico")]
        public int MecanicoId { get; set; }

        [ForeignKey("MecanicoId")]
        public Funcionario Mecanico { get; set; }

        [Required]
        [Display(Name = "Data da Manutenção")]
        public DateTime DataManutencao { get; set; }

        [Required]
        [Display(Name = "Rota")]
        public int RotaId { get; set; }

        [ForeignKey("RotaId")]
        public Rota Rota { get; set; }

        [Display(Name = "Itens Verificados pelo Mecânico")]
        public string ItensVerificados { get; set; }
    }
}
