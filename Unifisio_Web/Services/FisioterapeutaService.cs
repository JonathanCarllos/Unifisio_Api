using System.Text.Json;
using Unifisio_Web.Models;
using Unifisio_Web.Services.Interface;

namespace Unifisio_Web.Services
{
    public class FisioterapeutaService : IFisioterapeutaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/Fisioterapeutas/";
        private readonly JsonSerializerOptions _options;
        private FisioterapeutaViewModel FisioterapeutaVM;
        private IEnumerable<FisioterapeutaViewModel> FisioterapeutasVM;

        public FisioterapeutaService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<FisioterapeutaViewModel> CreateFisioterapeuta(FisioterapeutaViewModel fisioterapeutaVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFisioterapeutaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FisioterapeutaViewModel> FindFisioterapeutaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FisioterapeutaViewModel>> GetAllFisiotertapeuta()
        {
            throw new NotImplementedException();
        }

        public Task<FisioterapeutaViewModel> Update(FisioterapeutaViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
