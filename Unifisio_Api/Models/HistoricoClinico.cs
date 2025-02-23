using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.Models
{
    public class HistoricoClinico
    {        
        public int HistoricoClinicoId { get; set; }

        [StringLength(255), Required]
        public string? Diagnostico { get; set; }

        [StringLength(255), Required]
        public string? TratamentosAnteriores { get; set; }

        [StringLength(255), Required]
        public string? Restricoes { get; set; }

        
        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; } 
    }
}
