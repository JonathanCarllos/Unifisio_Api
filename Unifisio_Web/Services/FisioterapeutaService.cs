using System.Text;
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

        public async Task<FisioterapeutaViewModel> CreateFisioterapeuta(FisioterapeutaViewModel fisioterapeutaVM)
        {
            var cliente = _clientFactory.CreateClient("UnifisioApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(fisioterapeutaVM),
                Encoding.UTF8, "application/json");

            using (var response = await cliente.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    FisioterapeutaVM = await JsonSerializer
                        .DeserializeAsync<FisioterapeutaViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return FisioterapeutaVM;
        }

        public async Task<bool> DeleteFisioterapeutaById(int id)
        {
            var cliente = _clientFactory.CreateClient("UnifisioApi");

            using (var response = await cliente.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<FisioterapeutaViewModel> FindFisioterapeutaById(int id)
        {
            var cliente = _clientFactory.CreateClient("UnifisioApi");

            using (var response = await cliente.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    FisioterapeutaVM = await JsonSerializer
                        .DeserializeAsync<FisioterapeutaViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return FisioterapeutaVM;
        }

        public async Task<IEnumerable<FisioterapeutaViewModel>> GetAllFisiotertapeuta()
        {
            var cliente = _clientFactory.CreateClient("UnifisioApi");

            using (var response = await cliente.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    FisioterapeutasVM = await JsonSerializer
                        .DeserializeAsync<IEnumerable<FisioterapeutaViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return FisioterapeutasVM;
        }

        public async Task<FisioterapeutaViewModel> Update(FisioterapeutaViewModel viewModel)
        {
            var cliente = _clientFactory.CreateClient("UnifisioApi");

            FisioterapeutaViewModel fisioterapeutaUpdate = new FisioterapeutaViewModel();

            using (var response = await cliente.PutAsJsonAsync(apiEndpoint, viewModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    fisioterapeutaUpdate = await JsonSerializer
                        .DeserializeAsync<FisioterapeutaViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return fisioterapeutaUpdate;
        }
    }
}
