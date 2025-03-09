using System;
using System.ComponentModel.DataAnnotations;

public class FisioterapeutaDisponibilidadeDTO
{
    public int FisioterapeutaDisponibilidadeId { get; set; }

    [Required]
    public int FisioterapeutaId { get; set; }

    [Required]
    public DayOfWeek DiaSemana { get; set; }

    [Required]
    public TimeSpan HoraInicio { get; set; }

    [Required]
    public TimeSpan HoraFim { get; set; }
}
