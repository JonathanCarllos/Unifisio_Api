using Unifisio_Api.DTOs;

public interface IRegistroPresencaService
{
    Task AdicionarRegistroAsync(RegistroPresencaDto registroDto);
    Task<List<RegistroPresencaDto>> ObterPorPacienteAsync(int pacienteId);
    Task<List<RegistroPresencaDto>> ObterPorFisioterapeutaEDataAsync(int fisioterapeutaId, DateTime data);
}
