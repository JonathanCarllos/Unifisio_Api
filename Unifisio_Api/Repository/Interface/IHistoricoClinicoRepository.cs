using Unifisio_Api.Models;

namespace Unifisio_Api.Repository.Interface
{
    public interface IHistoricoClinicoRepository
    {
        Task<IEnumerable<HistoricoClinico>> GetAll();
        Task<HistoricoClinico> GetById(int id);
        Task<HistoricoClinico> Create(HistoricoClinico historicoClinico);
        Task<HistoricoClinico> Update(HistoricoClinico historicoClinico);
        Task<HistoricoClinico> Delete(int id);
    }
}
