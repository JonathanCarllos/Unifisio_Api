using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.DTOs
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Password { get; set; }
    }
}
