using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FisioterapeutasController : ControllerBase
    {
        private readonly IFisioterapeutaService _service;

        public FisioterapeutasController(IFisioterapeutaService service)
        {
            _service = service;
        }
    }
}
