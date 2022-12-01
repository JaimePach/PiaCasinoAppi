using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class GetParticipanteRifa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A que rifa pertenece el boleto??")]

        public int RifaID { get; set; }

        [Required(ErrorMessage = "Que Participante va a comprar el boleto??")]

        public int ParticipanteID { get; set; }

    }
}
