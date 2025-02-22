using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> Get()
        {
            var pacientes = await _service.GetPaciente();

            if (pacientes == null)
                return NotFound("Pacientes não encontrados ...");

            return Ok(pacientes);
        }

        [HttpGet("{id:int}", Name = "GetPaciente")]
        public async Task<ActionResult<PacienteDTO>> Get(int id)
        {
            var paciente = await _service.GetPacienteById(id);

            if (paciente == null)
                return NotFound("Paciente não encontrado ...");

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
                return BadRequest("Paciente não informado ...");

            await _service.AddPaciente(pacienteDTO);
            return CreatedAtRoute("GetPaciente", new { id = pacienteDTO.PacienteId }, pacienteDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PacienteDTO pacienteDTO)
        {
            if (id != pacienteDTO.PacienteId)
            {
                return BadRequest("Id do paciente não confere ...");
            }

            if (pacienteDTO == null)
                return BadRequest("Paciente não informado ...");

            await _service.UpdatePaciente(pacienteDTO);
            return Ok(pacienteDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var paciente = await _service.GetPacienteById(id);

            if (paciente == null)
            {
                return NotFound("Paciente não encontrado ...");
            }

            await _service.RemovePaciente(id);
            return Ok("Paciente removido ...");
        }
    }
}
