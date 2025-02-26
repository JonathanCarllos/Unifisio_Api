using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IPlanoTratamentoRepository
    {
        Task<PlanoTratamento> CriarPlano(PlanoTratamento plano);
        Task<PlanoTratamento> AtualizarPlano(PlanoTratamento plano);
        Task<PlanoTratamento?> BuscarPlanoPorPaciente(int pacienteId);
    }
}
