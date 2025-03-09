using Unifisio_Api.Models;

public class RegistroPresenca
{
    public int RegistroPresencaId { get; set; }
    public int PacienteId { get; set; }
    public int FisioterapeutaId { get; set; }
    public DateTime DataAtendimento { get; set; } // Data da consulta
    public bool Compareceu { get; set; }  // true = presente, false = falta
    public string? Observacoes { get; set; }

    // Relacionamentos
    public Paciente? Paciente { get; set; }
    public Fisioterapeuta? Fisioterapeuta { get; set; }
}
