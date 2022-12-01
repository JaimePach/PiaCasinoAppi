using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Falta rifa")]
        public string NombreRifa { get; set; }


      
    }
   
}
