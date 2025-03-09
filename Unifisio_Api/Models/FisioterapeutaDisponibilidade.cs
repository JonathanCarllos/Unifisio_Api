using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unifisio_Api.Models;

public class FisioterapeutaDisponibilidade
{
    [Key]
    public int FisioterapeutaDisponibilidadeId { get; set; }

    [Required]
    public int FisioterapeutaId { get; set; }

    [ForeignKey("FisioterapeutaId")]
    public Fisioterapeuta? Fisioterapeuta { get; set; }

    [Required]
    public DayOfWeek DiaSemana { get; set; }

    [Required]
    public TimeSpan HoraInicio { get; set; }

    [Required]
    public TimeSpan HoraFim { get; set; }
}
