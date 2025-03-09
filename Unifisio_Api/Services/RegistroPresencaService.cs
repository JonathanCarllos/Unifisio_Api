using Unifisio_Api.DTOs;

public class RegistroPresencaService : IRegistroPresencaService
{
    private readonly IRegistroPresencaRepository _repository;

    public RegistroPresencaService(IRegistroPresencaRepository repository)
    {
        _repository = repository;
    }

    public async Task AdicionarRegistroAsync(RegistroPresencaDto registroDto)
    {
        var registro = new RegistroPresenca
        {
            PacienteId = registroDto.PacienteId,
            FisioterapeutaId = registroDto.FisioterapeutaId,
            DataAtendimento = registroDto.DataAtendimento,
            Compareceu = registroDto.Compareceu,
            Observacoes = registroDto.Observacoes
        };

        await _repository.AdicionarRegistroAsync(registro);
    }

    public async Task<List<RegistroPresencaDto>> ObterPorPacienteAsync(int pacienteId)
    {
        var registros = await _repository.ObterPorPacienteAsync(pacienteId);
        return registros.Select(r => new RegistroPresencaDto
        {
            PacienteId = r.PacienteId,
            FisioterapeutaId = r.FisioterapeutaId,
            DataAtendimento = r.DataAtendimento,
            Compareceu = r.Compareceu,
            Observacoes = r.Observacoes
        }).ToList();
    }

    public async Task<List<RegistroPresencaDto>> ObterPorFisioterapeutaEDataAsync(int fisioterapeutaId, DateTime data)
    {
        var registros = await _repository.ObterPorFisioterapeutaEDataAsync(fisioterapeutaId, data);
        return registros.Select(r => new RegistroPresencaDto
        {
            PacienteId = r.PacienteId,
            FisioterapeutaId = r.FisioterapeutaId,
            DataAtendimento = r.DataAtendimento,
            Compareceu = r.Compareceu,
            Observacoes = r.Observacoes
        }).ToList();
    }
}
