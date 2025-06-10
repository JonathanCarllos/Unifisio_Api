using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FisioterapeutaDTO>>> Get()
        {
            var fisioterapeutas = await _service.GetFisioterapeuta();

            if (fisioterapeutas is null)
                return NotFound("Fisioterapeutas não encontrados ...");

            return Ok(fisioterapeutas);
        }

        [HttpGet("pacientes")]
        public async Task<ActionResult<IEnumerable<FisioterapeutaDTO>>> GetFisioterapeutasPacientes()
        {
            var fisioterapeutas = await _service.GetFisioterapeutaPaciente();

            if (fisioterapeutas == null)
            {
                return NotFound("Fisioterapeutas não encontrados ...");
            }

            return Ok(fisioterapeutas);
        }

        [HttpGet("{id:int}", Name = "GetFisioterapeuta")]
        public async Task<ActionResult<FisioterapeutaDTO>> Get(int id)
        {
            var fisioterapeuta = await _service.GetFisioterapeutaById(id);

            if (fisioterapeuta == null)
            {
                return NotFound("Fisioterapeuta não encontrado ...");
            }
            return Ok(fisioterapeuta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FisioterapeutaDTO fisioterapeutaDTO)
        {
            if (fisioterapeutaDTO == null)
                return BadRequest("Fisioterapeuta não informado ...");

            await _service.AddFisioterapeuta(fisioterapeutaDTO);
            return new CreatedAtRouteResult("GetFisioterapeuta", new { id = fisioterapeutaDTO.FisioterapeutaId }, fisioterapeutaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FisioterapeutaDTO fisioterapeutaDTO)
        {
            if (id != fisioterapeutaDTO.FisioterapeutaId)
                return BadRequest("Fisioterapeuta não informado ...");

            if (fisioterapeutaDTO == null)
                return BadRequest("Fisioterapeuta não informado ...");

            await _service.UpdateFisioterapeuta(fisioterapeutaDTO);
            return Ok(fisioterapeutaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fisioterapeuta = await _service.GetFisioterapeutaById(id);

            if (fisioterapeuta == null)
            {
                return NotFound("Fisioterapeuta não encontrado ...");
            }

            await _service.RemoveFisioterapeuta(id);
            return Ok("Fisioterapeuta removido com sucesso ...");
        }
    }
}
