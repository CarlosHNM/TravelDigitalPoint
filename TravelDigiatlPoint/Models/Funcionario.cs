using System.ComponentModel.DataAnnotations;

namespace TravelDigiatlPoint.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Número de Crachá")]
        public int NumeroDeCracha { get; set; }

        [Required]
        public string Pis { get; set; }

        [Required]
        public string Endereco { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cargo")]
        public Cargo Cargo { get; set; }

    }
}
