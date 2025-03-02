using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IConsultaProcedimentoRepository
    {
        Task<ConsultaProcedimento> CriarConsultaAsync(ConsultaProcedimento consulta);
        Task<List<ConsultaProcedimento>> ObterConsultasPorPacienteAsync(int pacienteId);
        Task<List<ConsultaProcedimento>> ObterConsultasPorFisioterapeutaAsync(int fisioterapeutaId);
    }
}
