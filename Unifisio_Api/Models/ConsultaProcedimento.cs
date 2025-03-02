using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifisio_Api.Models
{
    public class ConsultaProcedimento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O ID do fisioterapeuta é obrigatório.")]
        [ForeignKey("Fisioterapeuta")]
        public int FisioterapeutaId { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O tipo de procedimento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo de procedimento deve ter no máximo 100 caracteres.")]
        public string TipoProcedimento { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        public Fisioterapeuta? Fisioterapeuta { get; set; }
    }
}
