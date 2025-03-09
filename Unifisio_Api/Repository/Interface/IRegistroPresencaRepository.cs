public interface IRegistroPresencaRepository
{
    Task AdicionarRegistroAsync(RegistroPresenca registro);
    Task<List<RegistroPresenca>> ObterPorPacienteAsync(int pacienteId);
    Task<List<RegistroPresenca>> ObterPorFisioterapeutaEDataAsync(int fisioterapeutaId, DateTime data);
}
