using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IHorarioAtendimentoRepository
    {
        Task<HorarioAtendimento> CriarHorario(HorarioAtendimento horario);
        Task<List<HorarioAtendimento>> BuscarHorariosPorFisioterapeuta(int fisioterapeutaId);
        Task AtualizarDisponibilidade(int horarioId, bool disponivel);
    }
}
