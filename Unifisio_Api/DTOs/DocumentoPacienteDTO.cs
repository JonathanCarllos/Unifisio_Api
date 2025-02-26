using System.ComponentModel.DataAnnotations;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs
{
    public class DocumentoPacienteDTO
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
