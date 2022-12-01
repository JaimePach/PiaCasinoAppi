using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class CrearParticipanteRifa
    {
        [Required(ErrorMessage = "A que rifa pertenece el boleto??")]

        public int RifaID { get; set; }

        [Required(ErrorMessage = "Que Participante va a comprar el boleto??")]

        public int ParticipanteID { get; set; }
    }
}
