using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unifisio_Api.Models;

public class AgendamentoConsulta
{
    [Key]
    public int AgendamentoConsultaId { get; set; }

    [Required]
    public int PacienteId { get; set; }

    [Required]
    public int FisioterapeutaId { get; set; }

    [Required]
    public DateTime DataHora { get; set; }

    [Required]
    [StringLength(500)]
    public string Observacoes { get; set; } = string.Empty;

    [ForeignKey("PacienteId")]
    public Paciente? Paciente { get; set; }

    [ForeignKey("FisioterapeutaId")]
    public Fisioterapeuta? Fisioterapeuta { get; set; }
}
