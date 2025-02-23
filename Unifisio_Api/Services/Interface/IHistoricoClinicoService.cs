using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IHistoricoClinicoService
    {
        Task<IEnumerable<HistoricoClinicoDTO>> GetHistoricoClinico();
        Task<HistoricoClinicoDTO> GetHisToricoCLinicoById(int id);
        Task AddHistoricoClinico(HistoricoClinicoDTO historicoClinicoDTO);
        Task UpdateHistoricoClinico(HistoricoClinicoDTO historicoClinicoDTO);
        Task RemoveHistoricoClinico(int id);
    }
}
