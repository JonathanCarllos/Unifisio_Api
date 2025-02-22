using Unifisio_Api.DTOs;

namespace Unifisio_Api.Services.Interface
{
    public interface IFisioterapeutaService
    {
        Task<IEnumerable<FisioterapeutaDTO>> GetFisioterapeuta();
        Task<IEnumerable<FisioterapeutaDTO>> GetFisioterapeutaPaciente();
        Task<FisioterapeutaDTO> GetFisioterapeutaById(int id);
        Task AddFisioterapeuta(FisioterapeutaDTO fisioterapeutaDTO);
        Task UpdateFisioterapeuta(FisioterapeutaDTO fisioterapeutaDTO);
        Task RemoveFisioterapeuta(int id);
    }
}
