using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricoClinicosController : ControllerBase
    {
        private readonly IHistoricoClinicoService _service;

        public HistoricoClinicosController(IHistoricoClinicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoClinicoDTO>>> Get()
        {
            var historicoClinico = await _service.GetHistoricoClinico();

            if (historicoClinico == null)
                return NotFound("Histórico Clínico não encontrado ...");

            return Ok(historicoClinico);
        }

        [HttpGet("{id:int}", Name = "GetHistoricoClinico")]
        public async Task<ActionResult<HistoricoClinicoDTO>> Get(int id)
        {
            var historicoClinico = await _service.GetHisToricoCLinicoById(id);

            if (historicoClinico == null)
                return NotFound("Histórico Clínico não encontrado ...");

            return Ok(historicoClinico);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HistoricoClinicoDTO historicoClinicoDTO)
        {
            if (historicoClinicoDTO == null)
                return BadRequest("Histórico Clínico não informado ...");

            await _service.AddHistoricoClinico(historicoClinicoDTO);
            return CreatedAtRoute("GetHistoricoClinico", new { id = historicoClinicoDTO.HistoricoClinicoId }, historicoClinicoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] HistoricoClinicoDTO historicoClinicoDTO)
        {
            if (id != historicoClinicoDTO.HistoricoClinicoId)
            {
                return BadRequest("Id do Histórico Clínico não confere ...");
            }

            if (historicoClinicoDTO == null)
                return BadRequest("Histórico Clínico não informado ...");

            await _service.UpdateHistoricoClinico(historicoClinicoDTO);
            return Ok(historicoClinicoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
           var historicoClinico = await _service.GetHisToricoCLinicoById(id);

            if (historicoClinico == null)
            {
                return NotFound("Histórico Clínico não encontrado ...");
            }

            await _service.RemoveHistoricoClinico(id);
            return Ok("Histórico Clínico removido com sucesso ...");
        }
    }
}
