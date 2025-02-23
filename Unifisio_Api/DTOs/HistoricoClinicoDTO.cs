using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs
{
    public class HistoricoClinicoDTO
    {
        public int HistoricoClinicoId { get; set; }

        [StringLength(255), Required]
        public string? Diagnostico { get; set; }

        [StringLength(255), Required]
        public string? TratamentosAnteriores { get; set; }

        [StringLength(255), Required]
        public string? Restricoes { get; set; }

        [JsonIgnore]
        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
    }
}
