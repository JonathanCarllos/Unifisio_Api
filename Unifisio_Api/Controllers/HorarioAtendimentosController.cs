using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Services.Interface;

namespace Unifisio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HorarioAtendimentoController : ControllerBase
    {
        private readonly IHorarioAtendimentoService _service;

        public HorarioAtendimentoController(IHorarioAtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarHorario([FromBody] HorarioAtendimentoDTO horarioDTO)
        {
            try
            {
                var horarioCriado = await _service.CriarHorario(horarioDTO);
                return Ok(horarioCriado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar horário: {ex.Message}");
            }
        }

        [HttpGet("{fisioterapeutaId:int}")]
        public async Task<IActionResult> BuscarHorarios(int fisioterapeutaId)
        {
            var horarios = await _service.BuscarHorariosPorFisioterapeuta(fisioterapeutaId);
            if (horarios.Count == 0)
                return NotFound("Nenhum horário encontrado.");
            return Ok(horarios);
        }

        [HttpPut("atualizar-disponibilidade/{horarioId:int}")]
        public async Task<IActionResult> AtualizarDisponibilidade(int horarioId, [FromQuery] bool disponivel)
        {
            try
            {
                await _service.AtualizarDisponibilidade(horarioId, disponivel);
                return Ok("Disponibilidade atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar disponibilidade: {ex.Message}");
            }
        }
    }
}
