using System.ComponentModel.DataAnnotations;

namespace PiaCasinoAppi.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
