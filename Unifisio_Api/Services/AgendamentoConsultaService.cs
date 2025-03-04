using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.Repository.Interface;

public class AgendamentoConsultaService : IAgendamentoConsultaService
{
    private readonly IAgendamentoConsultaRepository _repository;

    public AgendamentoConsultaService(IAgendamentoConsultaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AgendamentoConsultaDTO>> ObterConsultasAsync()
    {
        return await _repository.ObterConsultasAsync();
    }

    public async Task<AgendamentoConsultaDTO?> ObterConsultaPorIdAsync(int id)
    {
        return await _repository.ObterConsultaPorIdAsync(id);
    }

    public async Task<AgendamentoConsultaDTO> AgendarConsultaAsync(AgendamentoConsultaDTO consultaDTO)
    {
        return await _repository.AgendarConsultaAsync(consultaDTO);
    }

    public async Task<bool> CancelarConsultaAsync(int id)
    {
        return await _repository.CancelarConsultaAsync(id);
    }
}
