using System;
using System.ComponentModel.DataAnnotations;

namespace Unifisio_Api.DTOs
{
    public class HorarioAtendimentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O dia da semana é obrigatório.")]
        [StringLength(20, ErrorMessage = "O dia da semana deve ter no máximo 20 caracteres.")]
        public string DiaSemana { get; set; } = string.Empty;

        [Required(ErrorMessage = "O horário de início é obrigatório.")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "O horário de fim é obrigatório.")]
        public TimeSpan HoraFim { get; set; }

        public bool Disponivel { get; set; } = true;

        [Required(ErrorMessage = "O ID do fisioterapeuta é obrigatório.")]
        public int FisioterapeutaId { get; set; }
    }
}
