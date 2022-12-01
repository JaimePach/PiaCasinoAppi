using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class GetParticipantesDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta rifa")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Falta Email")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
