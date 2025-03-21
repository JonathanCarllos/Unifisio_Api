using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultaProcedimentosController : ControllerBase
    {
        private readonly IConsultaProcedimentosService _service;

        public ConsultaProcedimentosController(IConsultaProcedimentosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarConsulta([FromBody] ConsultaProcedimentoDTO consultaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var consultaCriada = await _service.CriarConsultaAsync(consultaDTO);
                return Ok(consultaCriada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao registrar consulta: {ex.Message}");
            }
        }

        [HttpGet("paciente/{pacienteId:int}")]
        public async Task<ActionResult<List<ConsultaProcedimentoDTO>>> ObterConsultasPorPaciente(int pacienteId)
        {
            try
            {
                return Ok(await _service.ObterConsultasPorPacienteAsync(pacienteId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar consultas: {ex.Message}");
            }
        }

        [HttpGet("fisioterapeuta/{fisioterapeutaId:int}")]
        public async Task<ActionResult<List<ConsultaProcedimentoDTO>>> ObterConsultasPorFisioterapeuta(int fisioterapeutaId)
        {
            try
            {
                return Ok(await _service.ObterConsultasPorFisioterapeutaAsync(fisioterapeutaId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar consultas: {ex.Message}");
            }
        }
    }
}
