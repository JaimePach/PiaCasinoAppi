using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class ComprarBoletoDTO
    {
        [Required(ErrorMessage = "¿De que rifa es?")]
        public int RifaID { get; set; }

        
        public int? ParticipanteID { get; set; }

        [Required(ErrorMessage = "y que numero es?")]
        public int NumeroLoteria { get; set; }
    }
}
