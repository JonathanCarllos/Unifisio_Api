using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAgendamentoConsultaRepository
{
    Task<List<AgendamentoConsultaDTO>> ObterConsultasAsync();
    Task<AgendamentoConsultaDTO?> ObterConsultaPorIdAsync(int id);
    Task<AgendamentoConsultaDTO> AgendarConsultaAsync(AgendamentoConsultaDTO consultaDTO);
    Task<bool> CancelarConsultaAsync(int id);
}
