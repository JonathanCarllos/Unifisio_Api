using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.Models
{
    public class PlanoTratamento
    {        
        public int PlanoTratamentoId { get; set; }       
        public int TotalSessoes { get; set; }
        public int SessoesRealizadas { get; set; }
        public bool Concluido { get; set; }

        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
    }
}
