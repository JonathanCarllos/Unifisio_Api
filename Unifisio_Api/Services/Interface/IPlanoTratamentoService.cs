using System.Threading.Tasks;
using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IPlanoTratamentoService
    {
        Task<PlanoTratamentoDTO> CriarPlano(PlanoTratamentoDTO planoDTO);
        Task<PlanoTratamentoDTO?> BuscarPlanoPorPaciente(int pacienteId);
        Task AtualizarSessao(int pacienteId);
    }
}
