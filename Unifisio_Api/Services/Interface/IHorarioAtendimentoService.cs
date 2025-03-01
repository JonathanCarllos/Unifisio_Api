using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IHorarioAtendimentoService
    {
        Task<HorarioAtendimentoDTO> CriarHorario(HorarioAtendimentoDTO horarioDTO);
        Task<List<HorarioAtendimentoDTO>> BuscarHorariosPorFisioterapeuta(int fisioterapeutaId);
        Task AtualizarDisponibilidade(int horarioId, bool disponivel);
    }
}
