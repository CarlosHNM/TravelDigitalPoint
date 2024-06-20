using System.ComponentModel.DataAnnotations;

namespace TravelDigiatlPoint.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Required]
        [Display(Name = "Cor")]
        public string Cor { get; set; }

        [Display(Name = "Código do veículo")]
        public string CodVeiculo { get; set; }

    }
}
