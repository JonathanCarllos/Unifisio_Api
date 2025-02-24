using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifisio_Api.Models
{
    public class EvolucaoPaciente
    {        
        public int EvolucaoPacienteId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }

        [StringLength(255), Required]
        public string? Observacoes { get; set; }

        [StringLength(255), Required]
        public string? PlanoProximoPasso { get; set; }       
       
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
       
        public int FisioterapeutaId { get; set; }
        public Fisioterapeuta? Fisioterapeuta { get; set; }
    }
}
