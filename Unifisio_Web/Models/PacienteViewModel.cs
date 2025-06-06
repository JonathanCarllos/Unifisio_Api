using System.ComponentModel.DataAnnotations;

namespace Unifisio_Web.Models
{
    public class PacienteViewModel
    {
        public int PacienteId { get; set; }

        public string? Nome { get; set; }

        public string? CPF { get; set; }

        public string? Celular { get; set; }

        public string? Sexo { get; set; }

        public string? Profissao { get; set; }

        public string? EstadoCivil { get; set; }

        public string? Logradouro { get; set; }

        public string? NumeroCasa { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Cep { get; set; }

        public string? Estado { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? CelularResponsavel { get; set; }

        public string? NomeResponsavel { get; set; }

        public string? CpfResponsavel { get; set; }

        public string? RazaoSocial { get; set; }

        public string? Cnpj { get; set; }

        public string? TelefoneConv { get; set; }

        public string? LogradouroConv { get; set; }

        public string? NumeroConv { get; set; }

        public string? BairroConv { get; set; }

        public string? CidadeConv { get; set; }

        public string? CepConv { get; set; }

        public string? UfConvenio { get; set; }

        public string? TipoPlanos { get; set; }

        public string? ObsMedica { get; set; }

        public ICollection<FisioterapeutaViewModel>? Fisioterapeutas { get; set; }

        public ICollection<HistoricoClinicoViewModel>? HistoricosClinicos { get; set; }

    }
}
