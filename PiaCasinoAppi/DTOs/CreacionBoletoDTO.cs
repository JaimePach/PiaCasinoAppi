using PiaCasinoAppi.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class CreacionBoletoDTO
    {
        [Required(ErrorMessage = "¿De que rifa es?")]

        public int RifaID { get; set; }

        [Required(ErrorMessage = "y que numero es?")]

        public int NumeroLoteria { get; set; }

        
    }
}
