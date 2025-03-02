using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Unifisio_Api.Models;

namespace Unifisio_Api.DTOs
{
    public class RelatorioProdutividadeDTO
    {
        [Required(ErrorMessage = "O ID do relatório é obrigatório.")]
        public int RelatorioProdutividadeId { get; set; }

        [Required(ErrorMessage = "O ID do fisioterapeuta é obrigatório.")]
        public int FisioterapeutaId { get; set; }

        [Required(ErrorMessage = "O nome do fisioterapeuta é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do fisioterapeuta deve ter no máximo 100 caracteres.")]
        public string NomeFisioterapeuta { get; set; } = string.Empty;

        [Required(ErrorMessage = "O total de consultas é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O total de consultas não pode ser negativo.")]
        public int TotalConsultas { get; set; }

        [Required(ErrorMessage = "A data de início do período é obrigatória.")]
        public DateTime PeriodoInicio { get; set; }

        [Required(ErrorMessage = "A data de fim do período é obrigatória.")]
        public DateTime PeriodoFim { get; set; }

        [ForeignKey("FisioterapeutaId")]
        [JsonIgnore]
        public Fisioterapeuta? Fisioterapeuta { get; set; }
    }
}
