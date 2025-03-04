using System;
using System.ComponentModel.DataAnnotations;

public class AgendamentoConsultaDTO
{
    public int AgendamentoConsultaId { get; set; }

    [Required]
    public int PacienteId { get; set; }

    [Required]
    public int FisioterapeutaId { get; set; }

    [Required]
    public DateTime DataHora { get; set; }

    [StringLength(500, ErrorMessage = "As observações devem ter no máximo 500 caracteres.")]
    public string Observacoes { get; set; } = string.Empty;
}
