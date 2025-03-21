using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.DTOs
{
    public class RegisterModelDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Password { get; set; }
    }
}
