using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelDigiatlPoint.Models
{
    public class Rota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Origem")]
        public string Origem { get; set; }

        [Required]
        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Data e Hora de Partida")]
        public DateTime? DataHoraPartida { get; set; }

        [Display(Name = "Data e Hora de Chegada")]
        public DateTime? DataHoraChegada { get; set; }

        [Required]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

        [Required]
        [Display(Name = "Motorista")]
        public int FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public Funcionario Funcionario { get; set; }

        [Display(Name = "Algum problema com o Veículo")]
        public bool? FlDanos { get; set; }

        [Display(Name = "Observação do Motorista")]
        public string? ObservacaoMotorista { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FlDanos == true && string.IsNullOrWhiteSpace(ObservacaoMotorista))
            {
                yield return new ValidationResult("A observação do motorista é obrigatória quando há problemas com o veículo.", new[] { nameof(ObservacaoMotorista) });
            }
        }
    }
}
