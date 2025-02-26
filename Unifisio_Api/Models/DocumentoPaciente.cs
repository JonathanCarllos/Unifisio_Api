using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.Models
{
    public class DocumentoPaciente
    {
        public int DocumentoPacienteId { get; set; }

        [StringLength(100)]
        public string? NomeArquivo { get; set; }  

        [StringLength(255)]
        public string? CaminhoArquivo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataUpload { get; set; } = DateTime.Now;  
               
        public int PacienteId { get; set; }  
        public virtual Paciente? Paciente { get; set; }
    }
}
