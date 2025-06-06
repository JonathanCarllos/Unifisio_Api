using Unifisio_Web.Models;

namespace Unifisio_Web.Services.Interface
{
    public interface IFisioterapeutaService
    {
        Task<IEnumerable<FisioterapeutaViewModel>> GetAllFisiotertapeuta();
        Task<FisioterapeutaViewModel> FindFisioterapeutaById(int id);
        Task<FisioterapeutaViewModel> CreateFisioterapeuta(FisioterapeutaViewModel fisioterapeutaVM);
        Task<FisioterapeutaViewModel> Update(FisioterapeutaViewModel viewModel);
        Task<bool> DeleteFisioterapeutaById(int id);
    }
}
