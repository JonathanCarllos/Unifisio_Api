using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }

        [MaxLength(100), Required]
        public string? Nome { get; set; }

        [MaxLength(14), Required]
        public string? CPF { get; set; }

        [MaxLength(14), Required]
        public string? Celular { get; set; }

        [MaxLength(20), Required]
        public string? Sexo { get; set; }

        [MaxLength(50), Required]
        public string? Profissao { get; set; }

        [MaxLength(20), Required]
        public string? EstadoCivil { get; set; }

        [MaxLength(50), Required]
        public string? Logradouro { get; set; }

        [MaxLength(10), Required]
        public string? NumeroCasa { get; set; }

        [MaxLength(50), Required]
        public string? Bairro { get; set; }

        [MaxLength(50), Required]
        public string? Cidade { get; set; }

        [MaxLength(9), Required]
        public string? Cep { get; set; }

        [MaxLength(50), Required]
        public string? Estado { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress), Required]
        [MaxLength(75)]
        public string? Email { get; set; }

        [MaxLength(14)]
        public string? Telefone { get; set; }

        [MaxLength(14), Required]
        public string? CelularResponsavel { get; set; }

        [MaxLength(50)]
        public string? NomeResponsavel { get; set; }

        [MaxLength(14)]
        public string? CpfResponsavel { get; set; }

        [MaxLength(50)]
        public string? RazaoSocial { get; set; }

        [MaxLength(20)]
        public string? Cnpj { get; set; }

        [MaxLength(14)]
        public string? TelefoneConv { get; set; }

        [MaxLength(50)]
        public string? LogradouroConv { get; set; }

        [MaxLength(10)]
        public string? NumeroConv { get; set; }

        [MaxLength(50)]
        public string? BairroConv { get; set; }

        [MaxLength(50)]
        public string? CidadeConv { get; set; }

        [MaxLength(14)]
        public string? CepConv { get; set; }

        [MaxLength(50)]
        public string? UfConvenio { get; set; }

        [MaxLength(20)]
        public string? TipoPlanos { get; set; }

        [MaxLength(255), Required]
        public string? ObsMedica { get; set; }
        public ICollection<Fisioterapeuta>? Fisioterapeutas { get; set; }
    }
}
