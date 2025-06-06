using System.Text.Json.Serialization;

namespace Unifisio_Web.Models
{
    public class FisioterapeutaViewModel
    {
        public int FisioterapeutaId { get; set; }

        public string? Nome { get; set; }

        public string? Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Email { get; set; }

        public string? Celular { get; set; }

        public string? Crefito { get; set; }

        public string? Especialidade { get; set; }

        public string? Sexo { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Complemento { get; set; }

        public string? Cep { get; set; }

        public string? Estado { get; set; }
       
        public string? PacienteName { get; set; }

        public int PacienteId { get; set; }

    }
}
