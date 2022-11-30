using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.Entidades
{
    public class Boleto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "¿De que rifa es?")]
        public int RifaID { get; set;}


        public int ParticipanteID { get; set; }

        [Required(ErrorMessage = "y que numero es?")]
        public int NumeroLoteria { get; set; }

        public Rifa Rifa { get; set; }

        public Participante Participante { get; set; }

     
    }
}
