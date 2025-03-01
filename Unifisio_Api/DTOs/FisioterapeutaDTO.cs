using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs
{
    public class FisioterapeutaDTO
    {
        [Key]
        public int FisioterapeutaId { get; set; }

        [MaxLength(100), Required]
        public string? Nome { get; set; }

        [MaxLength(14), Required]
        public string? Cpf { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress), Required]
        [MaxLength(75)]
        public string? Email { get; set; }

        [MaxLength(14), Required]
        public string? Celular { get; set; }

        [MaxLength(20), Required]
        public string? Crefito { get; set; }

        [MaxLength(50), Required]
        public string? Especialidade { get; set; }

        [MaxLength(20), Required]
        public string? Sexo { get; set; }

        [MaxLength(50), Required]
        public string? Logradouro { get; set; }

        [MaxLength(10), Required]
        public string? Numero { get; set; }

        [MaxLength(30), Required]
        public string? Bairro { get; set; }

        [MaxLength(50), Required]
        public string? Cidade { get; set; }

        [MaxLength(50), Required]
        public string? Complemento { get; set; }

        [MaxLength(9), Required]
        public string? Cep { get; set; }

        [MaxLength(50), Required]
        public string? Estado { get; set; }

        [JsonIgnore]
        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
    }
}
