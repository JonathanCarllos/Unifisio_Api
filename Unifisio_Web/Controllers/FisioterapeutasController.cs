using Microsoft.AspNetCore.Mvc;
using Unifisio_Web.Models;
using Unifisio_Web.Services.Interface;

namespace Unifisio_Web.Controllers
{
    public class FisioterapeutasController : Controller
    {
        private readonly IFisioterapeutaService _fisioterapeutaService;

        public FisioterapeutasController(IFisioterapeutaService fisioterapeutaService)
        {
            _fisioterapeutaService = fisioterapeutaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FisioterapeutaViewModel>>> Index()
        {
            var result = await _fisioterapeutaService.GetAllFisiotertapeuta();

            if (result is null)
                return View("Error");

            return View(result);
        }
    }
}
