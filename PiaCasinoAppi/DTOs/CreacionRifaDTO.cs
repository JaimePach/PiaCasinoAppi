using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class CreacionRifaDTO
    {
        [Required(ErrorMessage = "Falta rifa")]
        public string NombreRifa { get; set; }



    }
}
