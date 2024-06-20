using System.ComponentModel.DataAnnotations;
using TravelDigiatlPoint.Models;

namespace TravelDigiatlPoint.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
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
        public string CPF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Cargo Cargo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
