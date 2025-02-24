using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolucaoPacientesController : ControllerBase
    {
        private readonly IEvolucaoPacienteService _service;

        public EvolucaoPacientesController(IEvolucaoPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvolucaoPacienteDTO>>> Get()
        {
            var evolucoesPaciente = await _service.GetEvolucaoPaciente();

            if (evolucoesPaciente == null)
                return NotFound("Evoluções de pacientes não encontradas ...");

            return Ok(evolucoesPaciente);
        }

        [HttpGet("{id:int}", Name = "GetEvolucaoPaciente")]
        public async Task<ActionResult<EvolucaoPacienteDTO>> Get(int id)
        {
            var evolucaoPaciente = await _service.GetEvolucaoPacienteById(id);

            if (evolucaoPaciente == null)
                return NotFound("Evolução de paciente não encontrada ...");

            return Ok(evolucaoPaciente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EvolucaoPacienteDTO evolucaoPacienteDTO)
        {
            if (evolucaoPacienteDTO == null)
                return BadRequest("Evolução de paciente não informada ...");

            await _service.AddEvolucaoPaciente(evolucaoPacienteDTO);
            return CreatedAtRoute("GetEvolucaoPaciente", new { id = evolucaoPacienteDTO.EvolucaoPacienteId }, evolucaoPacienteDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EvolucaoPacienteDTO evolucaoPacienteDTO)
        {
            if (id != evolucaoPacienteDTO.EvolucaoPacienteId)
            {
                return BadRequest("Id da evolução de paciente não confere ...");
            }

            if (evolucaoPacienteDTO == null)
                return BadRequest("Evolução de paciente não informada ...");

            await _service.UpdateEvolucaoPaciente(evolucaoPacienteDTO);
            return Ok("Evolução de paciente atualizada com sucesso ...");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var evolucaoPaciente = await _service.GetEvolucaoPacienteById(id);

            if (evolucaoPaciente == null)
                return NotFound("Evolução de paciente não encontrada ...");

            await _service.RemoveEvolucaoPaciente(id);
            return Ok("Evolução de paciente excluída com sucesso ...");
        }
    }
}
