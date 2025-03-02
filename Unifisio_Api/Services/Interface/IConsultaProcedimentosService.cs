using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IConsultaProcedimentosService
    {
        Task<ConsultaProcedimentoDTO> CriarConsultaAsync(ConsultaProcedimentoDTO consultaDTO);
        Task<List<ConsultaProcedimentoDTO>> ObterConsultasPorPacienteAsync(int pacienteId);
        Task<List<ConsultaProcedimentoDTO>> ObterConsultasPorFisioterapeutaAsync(int fisioterapeutaId);
    }
}
