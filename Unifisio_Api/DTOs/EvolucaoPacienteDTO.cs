using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs
{
    public class EvolucaoPacienteDTO
    {
        public int EvolucaoPacienteId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }

        [StringLength(255), Required]
        public string? Observacoes { get; set; }

        [StringLength(255), Required]
        public string? PlanoProximoPasso { get; set; }

        public int PacienteId { get; set; }

        [JsonIgnore]
        public Paciente? Paciente { get; set; }

        public int FisioterapeutaId { get; set; }

        [JsonIgnore]
        public Fisioterapeuta? Fisioterapeuta { get; set; }
    }
}
