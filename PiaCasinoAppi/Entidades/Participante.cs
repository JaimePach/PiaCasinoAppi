using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.Entidades
{
    public class Participante
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "Falta rifa")]
        public string Nombre { get; set;}

        [Required(ErrorMessage = "Falta Email")]
        [EmailAddress]
        public string Email { get; set; }

 
        public List<ParticipanteRifa> ParticipanteRifa { get; set;}

        public List<Boleto> Boleto { get; set; }

    }
}
