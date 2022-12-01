using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class CreacionPremioDTO
    {
        [Required(ErrorMessage = "Cual es el premio??")]
        public string Objeto { get; set; }

        [Required(ErrorMessage = "Que lugar se lleva el premio??")]

        public int Orden { get; set; }

        [Required(ErrorMessage = "A que rifa pertenece el premio???s")]

        public int RifaID { get; set; }
    }
}
